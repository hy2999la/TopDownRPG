using UnityEngine;

public class CameraMotor : MonoBehaviour {
	public Transform lookAt;
	public float boundX = 0.15f;
	public float boundY = 0.05f;

	// Update is called once per frame
	private void LateUpdate() {
		Vector3 delta = Vector3.zero;

		// Check to see if the object we are looking at is within the bounds of our camera frame
		float deltaX = lookAt.position.x - transform.position.x;
		if (deltaX > boundX || deltaX < -boundX) {
			delta.x = deltaX > 0 ? deltaX - boundX : deltaX + boundX;
		}

		float deltaY = lookAt.position.y - transform.position.y;
		if (deltaY > boundY || deltaY < -boundY) {
			delta.y = deltaY > 0 ? deltaY - boundY : deltaY + boundY;
		}

		transform.position += new Vector3(delta.x, delta.y, 0);
	}
}
