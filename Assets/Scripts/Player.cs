using UnityEngine;

public class Player : MonoBehaviour
{
	private BoxCollider2D boxCollider;
	private Vector3 moveDelta;
	private RaycastHit2D hit;

	// Start is called before the first frame update
	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		// Look for keyboard inputs to add to moveDelta
		//  Input is defined in InputManager (axis: Horizontal and Vertical)
		//  a,left for - / d,right for + Horizontal
		//  s,down for - / w,up for + Vertical
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		// Reset moveDelta
		moveDelta = new Vector3(x, y, 0);

		// Swap sprite direction based on moveDelta
		if (moveDelta.x > 0)
		{
			transform.localScale = Vector3.one;
		}
		else if (moveDelta.x < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		// Collision detection by casting a box in the Y direction first, if our collider returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
		if (hit.collider == null)
		{
			// Y Movement
			transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
		}

		// Collision detection by casting a box in the X direction first, if our collider returns null, we are free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
		if (hit.collider == null)
		{
			// Y Movement
			transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
		}

	}
}
