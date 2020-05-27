using UnityEngine;
using System;

public class CashRegister : MonoBehaviour, IInteractable
{

    public void Interact(GameObject player)
    {
        
        player.GetComponentInChildren<IconBox>().Close();//close the icon bubble

        PlayerInteracter playerInteracter = player.GetComponent<PlayerInteracter>();
        PlayerController playerController = player.GetComponent<PlayerController>();
        ItemController itemToBuy = player.GetComponent<PlayerInteracter>().heldItem;

        playerController.SubtractMoney(itemToBuy.itemInfo.price); //charge the player
        playerController.AddScore( (int) Math.Ceiling(itemToBuy.itemInfo.price * itemToBuy.discount) ); //add score for buying item based on discount (ceilinged for int value)

        playerInteracter.heldItem = null;


    }
}
