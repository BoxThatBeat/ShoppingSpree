using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
	public GameObject target;
	public IconBox iconBox;
	public ItemController heldItem;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Selectable"))
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
		if (col.gameObject == target && col.CompareTag("Selectable"))
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

		//show information about object selected
		ItemController item = target.GetComponent<ItemController>();
		if (item != null && heldItem == null)
		{
			item.DisplayItemInfo();
			return;
		}

		CashRegister cashReg = target.GetComponent<CashRegister>();
		if (cashReg != null && heldItem != null)
		{
			cashReg.DisplayItemInfo();
			return;
		}

	}

	void Deselect()
	{
		//unhighlight the unselected object
		SpriteRenderer[] srs = target.GetComponentsInChildren<SpriteRenderer>(); 
		foreach (SpriteRenderer sr in srs)
		{
			sr.color = Color.white;
		}

		//close information about object selected
		ItemController item = target.GetComponent<ItemController>();
		if (item != null && heldItem == null)
		{
			item.CloseDisplay();
			return;
		}

		CashRegister cashReg = target.GetComponent<CashRegister>();
		if (cashReg != null && heldItem != null)
		{
			cashReg.CloseDisplay();
			return;
		}
	}

	public void OnUse() //called when player's use button is pressed
	{
		if (target == null)
			return;

		ItemController item = target.GetComponent<ItemController>();
		if (item != null && heldItem == null)
		{
			item.Interact(gameObject);
			return;
		}
		
		CashRegister cashReg = target.GetComponent<CashRegister>();
		if (cashReg != null && heldItem != null)
		{
			cashReg.Interact(gameObject);
			return;
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
