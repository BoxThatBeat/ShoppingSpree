using UnityEngine;
using System;

public class CashRegister : MonoBehaviour, IInteractable
{

    public void Interact(GameObject player)
    {
        PlayerInteracter playerInteracter = player.GetComponent<PlayerInteracter>();

        if (playerInteracter.heldItem != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            ItemController itemToBuy = player.GetComponent<PlayerInteracter>().heldItem;

            if (playerController.money - itemToBuy.itemInfo.price >= 0) //make sure player has enough money
            {
                player.GetComponentInChildren<IconBox>().Close();//close the icon bubble

                playerController.SubtractMoney(itemToBuy.newPrice); //charge the player
                playerController.AddScore((int)Math.Ceiling(itemToBuy.itemInfo.price * itemToBuy.discount)); //add score for buying item based on discount (ceilinged for int value)

                if (playerInteracter.heldItem.itemInfo.bonusItemIndex != -1)
                {
                    //Start a coroutine to add more score in a two seconds with a special sound effect
                    //send a event call to UI systsem with the bonus index to cover the item with the players face
                    //and it will also make the bonus item not a bonus item anymore
                    Debug.Log("BONUS ITEM");
                    
                }

                playerInteracter.heldItem = null;
            } 
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
