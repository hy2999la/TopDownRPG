using UnityEngine;

public class WeaponCollidable : Collidable {
	// Damage structure
	public int damageNum = 1;
	public float pushForce = 2.0f;

	// Upgrade
	public int weaponLevel = 0;
	private SpriteRenderer spriteRenderer;

	// Swing
	public float cooldown = 0.5f;
	private float lastSwing;

	// Start is called before the first frame update
	protected override void Start() {
		base.Start();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	protected override void Update() {
		base.Update();

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (Time.time - lastSwing > cooldown) {
				lastSwing = Time.time;
				Swing();
			}
		}
	}

	private void Swing() {
		Debug.Log("Swing");
	}

	protected override void OnCollide(Collider2D collider) {
		if (collider.CompareTag("Hittable")) {

			// Can't hit your own player
			if (collider.name == "Player") {
				return;
			}

			Damage damage = new Damage {
				origin = transform.position,
				damageNum = damageNum,
				pushForce = pushForce
			};

			collider.SendMessage("ReceiveDamage", damage);
		}
	}
}
