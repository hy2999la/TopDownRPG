using UnityEngine;

public class Collidable : MonoBehaviour {
	public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
	private readonly Collider2D[] hits = new Collider2D[10];

	// Start is called before the first frame update
	protected virtual void Start() {
		boxCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	protected virtual void Update() {
		// Checking for collisions
		_ = boxCollider.OverlapCollider(filter, hits);
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i] == null) {
				continue;
			}

			OnCollide(hits[i]);

			// We are done with this Collider object, clean up found collision in hits array
			hits[i] = null;
		}
	}

	protected virtual void OnCollide(Collider2D collider) {
		Debug.Log(collider.name);
	}
}
