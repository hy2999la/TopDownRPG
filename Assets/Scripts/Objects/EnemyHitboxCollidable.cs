using UnityEngine;

public class EnemyHitboxCollidable : Collidable {
	// Damage
	public int damageNum = 1;
	public float pushForce = 3;

	protected override void OnCollide(Collider2D collider) {
		if (collider.name == "Player") {
			Damage damage = new Damage {
				damageNum = damageNum,
				origin = transform.position,
				pushForce = pushForce
			};

			collider.SendMessage("ReceiveDamage", damage);
		}
	}
}
