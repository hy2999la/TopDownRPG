using UnityEngine;

public class Enemy : Moveable {
	// Enemy Stats
	public int experience = 1; // Amount of experience this enemy gives after death

	// Enemy AI fields
	public float triggerDist = 1; // Distance until enemy notices player
	public float chaseDist = 5; // Distance until enemy stops chasing player and returns to original position
	private bool chasing; // Are we chasing the player
	private bool collidingWithPlayer; // If colliding already, we stop chasing (since we are already hitting the player)
	private Transform playerTransform; // Player
	private Vector3 startingPosition; // Original position

	// Hitbox
	private ContactFilter2D filter;
	private BoxCollider2D hitbox;
	private Collider2D[] hits = new Collider2D[10];

	protected override void Start() {
		base.Start();
		playerTransform = GameManager.instance.player.transform;
		startingPosition = transform.position;
		hitbox = transform.Find("Hitbox").GetComponent<BoxCollider2D>();
	}

	private void FixedUpdate() {
		// Is the player in range?
		if (Vector3.Distance(playerTransform.position, startingPosition) < chaseDist) {
			if (Vector3.Distance(playerTransform.position, startingPosition) < triggerDist) {
				chasing = true;
			}

			// If we are chasing now:
			if (chasing) {
				// If we are not colliding with the player already
				if (!collidingWithPlayer) {
					// Move the enemy towards the player
					UpdateMotor((playerTransform.position - transform.position).normalized);
				}
			} else {
				// Move the enemy back to the starting position
				UpdateMotor(startingPosition - transform.position);
			}
		} else {
			// Move the enemy back to the starting position
			UpdateMotor(startingPosition - transform.position);
			chasing = false;
		}

		collidingWithPlayer = false;
		boxCollider.OverlapCollider(filter, hits);
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i] == null) {
				continue;
			}

			if (hits[i].tag == "Hittable" && hits[i].name == "Player") {
				collidingWithPlayer = true;
			}

			// We are done with this collider object, clean it up
			hits[i] = null;
		}

		UpdateMotor(Vector3.zero);
	}

	protected override void Death() {
		// Remove enemy
		Destroy(gameObject);
		GameManager.instance.experience += experience;
		GameManager.instance.ShowText(
			$"+{experience} xp",
			35,
			Color.green,
			transform.position,
			Vector3.up * 25,
			1.5f
		);

	}
}
