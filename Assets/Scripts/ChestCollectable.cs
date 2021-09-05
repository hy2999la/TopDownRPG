using UnityEngine;

public class ChestCollectable : Collectable {
	public Sprite emptyChest;
	public int goldAmount = 10;

	protected override void OnCollect() {
		if (!collected) {
			collected = true;
			GetComponent<SpriteRenderer>().sprite = emptyChest;
			GameManager.instance.ShowText(
				$"+{goldAmount} Gold!",
				20,
				new Color(1f, 0.761586f, 0.2207547f),
				new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, 0),
				Vector3.up * 25,
				1.5f
			);
		}
	}
}
