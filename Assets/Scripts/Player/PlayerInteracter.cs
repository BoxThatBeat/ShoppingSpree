﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteracter : MonoBehaviour
{
	public GameObject target;
	public IconBox iconBox;
	
	[SerializeField]
	private Item heldItem;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Selectable")
		{
			if (target != col.gameObject && target != null)
			{
				Deselect();
			}

			target = col.gameObject;

			SpriteRenderer[] srs = target.GetComponentsInChildren<SpriteRenderer>(); //highlight selected object
			foreach (SpriteRenderer sr in srs)
			{
				sr.color = new Color(190, 190, 190, 0.7f);
			}
		}
		
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject == target && col.tag == "Selectable")
		{
			Deselect();
			target = null;
		}
	}

	void Deselect()
	{
		SpriteRenderer[] srs = target.GetComponentsInChildren<SpriteRenderer>(); //unhighlight the unselected object
		foreach (SpriteRenderer sr in srs)
		{
			sr.color = Color.white;
		}
	}

	public void OnUse() //called when player's use button is pressed
	{
		if (target == null)
			return;

		ItemController item = target.GetComponent<ItemController>();
		if (item != null)
		{
			Debug.Log(item.gameObject.tag);
			item.Interact(gameObject);
		}

		/*
		TableTile table = target.GetComponent<TableTile>();
		if (table != null)
		{
			table.Interact(crop, tool, this);
		}
		*/
	}

	public void SetItem(Item itemToHold)
	{
		heldItem = itemToHold;
		DisplayItem();
	}

	void DisplayItem()
	{
		iconBox.SetIcon(heldItem.sprite);
	}
}