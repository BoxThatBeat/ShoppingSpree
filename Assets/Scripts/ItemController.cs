using UnityEngine;

public class ItemController : MonoBehaviour, IInteractable
{

    [SerializeField] private Item itemInfo = null;

    public void InitItem(Item type)
    {
        itemInfo = type;
        GetComponent<SpriteRenderer>().sprite = itemInfo.sprite;
    }

    public void Interact(GameObject player)
    {
        PlayerInteracter playerIter = player.GetComponent<PlayerInteracter>();

        if (playerIter.heldItem == null)//make the the player is not holding anything
        {
            playerIter.SetItem(itemInfo); //give the player the item info

            Destroy(this.gameObject);//delete the item picked up, the player must sell the item and cannot leave the shop until they do
        }
    }
}
