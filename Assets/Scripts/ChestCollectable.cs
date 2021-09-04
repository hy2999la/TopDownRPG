using UnityEngine;

public class ChestCollectable : Collectable
{
	public Sprite emptyChest;
	public int goldAmount = 10;

	protected override void OnCollect()
	{
		if (!collected)
		{
			collected = true;
			GetComponent<SpriteRenderer>().sprite = emptyChest;
			Debug.Log($"Granted {goldAmount} gold");
		}
	}
}
