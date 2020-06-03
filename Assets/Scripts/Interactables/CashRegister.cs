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

                playerController.SubtractMoney(itemToBuy.newPrice); //charge the player
                playerController.AddScore(itemToBuy.scoreRewarded); //add score for buying item based on discount (ceilinged for int value)

                playerController.numItemsBought++;

                int bonusIndex = playerInteracter.heldItem.itemInfo.bonusItemIndex;
                if (bonusIndex != -1)
                {
                    //Start a coroutine to add more score in a two seconds with a special sound effect
                    StartCoroutine(AddBonusScore(playerController));

                    //send a event call to UI systsem with the bonus index to cover the item with the players face and  make the bonus item not a bonus item anymore
                    EventSystemUI.current.BoughtBonusItem(playerController.playerId, bonusIndex);
                }

                Destroy(playerInteracter.heldItem.gameObject); //free up memory when item bought
                playerInteracter.heldItem = null;

                SetSaying(withItemSaying);
            }
            else
            {
                //clerk says you cant afford that in the bubble speach
                SetSaying(cantAffordSaying);
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
        SetSaying(withoutItemSaying);
        display.SetIcon(null); //open canvas with animation
    }

    public void CloseDisplay()
    {
        display.Close();
    }
}
