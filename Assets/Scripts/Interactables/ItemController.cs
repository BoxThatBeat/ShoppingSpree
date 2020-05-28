﻿using System;
using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour, IInteractable
{

    [NonSerialized] public Item itemInfo = null;
    [NonSerialized] public float discount = 0;
    [NonSerialized] public int newPrice = 0;

    [SerializeField] private TextMeshProUGUI wasPrice = null;
    [SerializeField] private TextMeshProUGUI nowPrice = null;
    [SerializeField] private TextMeshProUGUI percentageOff = null;
    private bool interactable = true;

    public void InitItem(Item type, Discount storeDiscount)
    {
        itemInfo = type;
        discount = UnityEngine.Random.Range(storeDiscount.minDiscount, storeDiscount.maxDiscount);
        newPrice = (int) Math.Ceiling(itemInfo.price * (1 - discount));

        //set up sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemInfo.sprite;
        sr.sortingLayerName = "StoreObjectsInterior";

        //set up item info canvas
        wasPrice.text = itemInfo.price.ToString();
        nowPrice.text = newPrice.ToString();

        int percentOff = (int)Math.Ceiling(discount*100);
        percentageOff.text = percentOff.ToString() + "% OFF";

    }

    public void Interact(GameObject player)
    {
        PlayerInteracter playerInteracter = player.GetComponent<PlayerInteracter>();

        if (interactable && playerInteracter.heldItem == null)
        {

            playerInteracter.SetItem(this); //give the player the item info

            GetComponent<SpriteRenderer>().enabled = false; //make the item disapear
            interactable = false;
            CloseDisplay();
        }
    }

    public void OpenDisplay()
    {
        if (interactable)
            GetComponentInChildren<Canvas>().enabled = true;
    }

    public void CloseDisplay()
    {
        GetComponentInChildren<Canvas>().enabled = false;
    }
}