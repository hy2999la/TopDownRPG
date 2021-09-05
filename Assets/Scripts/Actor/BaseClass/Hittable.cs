using UnityEngine;

public class Hittable : MonoBehaviour {
	// Character Stats
	public int hp = 10;
	public int maxHp = 10;
	public float pushRecoverySpeed = 0.2f;

	// I-frames
	protected float immuneTime = 1.0f;
	protected float lastImmune;

	// Push
	protected Vector3 pushDirection;

	protected virtual void ReceiveDamage(Damage damage) {
		if (Time.time - lastImmune > immuneTime) {
			lastImmune = Time.time;
			hp -= damage.damageNum;
			pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;

			GameManager.instance.ShowText(
				$"-{damage.damageNum}",
				20,
				Color.red,
				transform.position,
				Vector3.up * 25,
				1.5f
			);

			if (hp <= 0) {
				hp = 0;
				Death();
			}
		}
	}

	protected virtual void Death() {

	}

	// Start is called before the first frame update
	private void Start() {

	}

	// Update is called once per frame
	private void Update() {

	}
}
