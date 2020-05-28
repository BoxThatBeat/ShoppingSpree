using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
	public GameObject target;
	public IconBox iconBox;
	public ItemController heldItem;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<IInteractable>() != null)
		{
			if (target != col.gameObject && target != null)
			{
				Deselect();
			}

			target = col.gameObject;
			Select();
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject == target && col.GetComponent<IInteractable>() != null)
		{
			Deselect();
			target = null;
		}
	}

	void Select()
	{
		//highlight selected object
		SpriteRenderer[] srs = target.GetComponentsInChildren<SpriteRenderer>(); 
		foreach (SpriteRenderer sr in srs)
		{
			sr.color = new Color(190, 190, 190, 0.7f);
		}

		Interact(target, "openDisplay");

	}

	void Deselect()
	{
		//unhighlight the unselected object
		SpriteRenderer[] srs = target.GetComponentsInChildren<SpriteRenderer>(); 
		foreach (SpriteRenderer sr in srs)
		{
			sr.color = Color.white;
		}

		Interact(target, "closeDisplay");
	}

	public void OnUse() //called when player's use button is pressed
	{
		if (target == null)
			return;

		Interact(target, "interact");
	}

	private void Interact(GameObject target, string interaction)
	{
		IInteractable interactable = target.GetComponent<IInteractable>(); 
		if (interactable != null)//make sure the item interacting with implements the Interactable interface
		{
			switch (interaction)
			{
				case "interact":
					interactable.Interact(gameObject);
					break;

				case "openDisplay":
					interactable.OpenDisplay();
					break;

				case "closeDisplay":
					interactable.CloseDisplay();
					break;

			}
		}
	}

	public void SetItem(ItemController itemToHold)
	{
		heldItem = itemToHold;
		DisplayItem();
	}

	void DisplayItem()
	{
		iconBox.SetIcon(heldItem.itemInfo.sprite);
	}
}
