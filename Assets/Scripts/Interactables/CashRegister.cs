using UnityEngine;
using TMPro;
using System.Collections;

public class CashRegister : MonoBehaviour, IInteractable
{
    private IconBox display = null;

    [SerializeField] private TextMeshProUGUI withoutItemSaying = null;
    [SerializeField] private TextMeshProUGUI withItemSaying = null;
    [SerializeField] private TextMeshProUGUI cantAffordSaying = null;

    private TextMeshProUGUI activeSaying = null;

    private void Start()
    {
        display = GetComponentInChildren<IconBox>();
        activeSaying = withoutItemSaying;
        activeSaying.enabled = true;
    }

    private void SetSaying(TextMeshProUGUI saying)
    {
        activeSaying.enabled = false;
        activeSaying = saying;
        activeSaying.enabled = true;
    }

    public void Interact(GameObject player)
    {
        PlayerInteracter playerInteracter = player.GetComponent<PlayerInteracter>();

        if (playerInteracter.heldItem != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            ItemController itemToBuy = player.GetComponent<PlayerInteracter>().heldItem;

            if (playerController.money - itemToBuy.newPrice >= 0) //make sure player has enough money
            {
                playerInteracter.CloseDisplay();

                //set money and score for player
                playerController.SubtractMoney(itemToBuy.newPrice); //charge the player
                StartCoroutine(GiveScoreToPlayer(playerController, itemToBuy.scoreRewarded, playerInteracter.heldItem.itemInfo.bonusItemIndex));
                EventSystemGame.current.PlaySound("KaChing");

                //increase stats of player for endgame stats
                playerController.numItemsBought++;
                playerController.moneySpent += itemToBuy.newPrice;

                //free up memory when item bought
                Destroy(playerInteracter.heldItem.gameObject); 
                playerInteracter.heldItem = null;

                //set what the clerk is saying
                SetSaying(withItemSaying);
            }
            else
            {
                //clerk says you cant afford that in the bubble speach
                SetSaying(cantAffordSaying);
            }
        }
    }

    private IEnumerator GiveScoreToPlayer(PlayerController player,int scoreToAdd, int bonusIndex)
    {
        yield return new WaitForSeconds(0.8f);
        player.AddScore(scoreToAdd); //add score for buying item based on discount (ceilinged for int value)

        //check if item is a bonus Item
        if (bonusIndex != -1)
        {
            yield return new WaitForSeconds(1.5f);
            player.AddScore(GameManager.Instance.bonusItemReward); //get the bonus from the game manager as it is constantly increasing throughout the match

            //send a event call to UI systsem with the bonus index to cover the item with the players face and  make the bonus item not a bonus item anymore
            EventSystemUI.current.BoughtBonusItem(player.playerId, bonusIndex);
        }
    }

    public void OpenDisplay(GameObject player)
    {
        EventSystemGame.current.PlaySound("Pop");
        SetSaying(withoutItemSaying);
        display.SetIcon(null); //open canvas with animation
    }

    public void CloseDisplay()
    {
        display.Close();
    }
}
