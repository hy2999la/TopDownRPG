using UnityEngine;

public abstract class Moveable : Hittable {
	protected BoxCollider2D boxCollider;
	protected Vector3 moveDelta;
	protected RaycastHit2D hit;
	protected float ySpeed = 0.75f;
	protected float xSpeed = 1.0f;

	// Start is called before the first frame update
	protected virtual void Start() {
		boxCollider = GetComponent<BoxCollider2D>();
	}

	protected virtual void UpdateMotor(Vector3 input) {
		// Reset moveDelta
		moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

		// Swap sprite direction based on moveDelta
		if (moveDelta.x > 0) {
			transform.localScale = Vector3.one;
		} else if (moveDelta.x < 0) {
			transform.localScale = new Vector3(-1, 1, 1);
		}

		// Add movement based on push from hits
		moveDelta += pushDirection;

		// Reduce pushDirection based on pushRecovery
		pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

		// Collision detection by casting a box in the Y direction first, if our collider returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
		if (hit.collider == null) {
			// Y Movement
			transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
		}

		// Collision detection by casting a box in the X direction first, if our collider returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
		if (hit.collider == null) {
			// Y Movement
			transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
		}
	}
}
