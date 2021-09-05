using UnityEngine;

public class Player : Moveable {
	private void FixedUpdate() {
		// Look for keyboard inputs to add to moveDelta
		//  Input is defined in InputManager (axis: Horizontal and Vertical)
		//  a,left for - / d,right for + Horizontal
		//  s,down for - / w,up for + Vertical
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		UpdateMotor(new Vector3(x, y, 0));
	}
}
