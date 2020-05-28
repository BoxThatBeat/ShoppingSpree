using UnityEngine;
using System;

public class CashRegister : MonoBehaviour, IInteractable
{

    public void Interact(GameObject player)
    {
        PlayerInteracter playerInteracter = player.GetComponent<PlayerInteracter>();

        if (playerInteracter.heldItem != null)
        {
            player.GetComponentInChildren<IconBox>().Close();//close the icon bubble

            PlayerController playerController = player.GetComponent<PlayerController>();
            ItemController itemToBuy = player.GetComponent<PlayerInteracter>().heldItem;

            playerController.SubtractMoney(itemToBuy.newPrice); //charge the player
            playerController.AddScore((int)Math.Ceiling(itemToBuy.itemInfo.price * itemToBuy.discount)); //add score for buying item based on discount (ceilinged for int value)

            playerInteracter.heldItem = null;
        }
    }
    public void OpenDisplay()
    {
        Debug.Log("cashOpen");
    }

    public void CloseDisplay()
    {
        Debug.Log("cashClosed");
    }
}
