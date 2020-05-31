using UnityEngine;
using System;
using System.Collections;

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
                playerController.AddScore(itemToBuy.scoreRewarded); //add score for buying item based on discount (ceilinged for int value)


                int bonusIndex = playerInteracter.heldItem.itemInfo.bonusItemIndex;
                if (bonusIndex != -1)
                {
                    Debug.Log("BONUS ITEM FOUND");
                    //Start a coroutine to add more score in a two seconds with a special sound effect
                    StartCoroutine(AddBonusScore(playerController));

                    //send a event call to UI systsem with the bonus index to cover the item with the players face and  make the bonus item not a bonus item anymore
                    EventSystemUI.current.BoughtBonusItem(playerController.playerId, bonusIndex);
                    
                }

                playerInteracter.heldItem = null;
            } 
        }
    }

    private IEnumerator AddBonusScore(PlayerController player)
    {
        yield return new WaitForSeconds(2f);
        player.AddScore(GameManager.Instance.bonusItemReward); //get the bonus from the game manager as it is constantly increasing throughout the match
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
