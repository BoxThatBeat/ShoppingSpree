using UnityEngine;

public class ItemController : MonoBehaviour, IInteractable
{

    public Item itemInfo = null;
    public float discount;
    private bool interactable = true;

    public void InitItem(Item type, Discount storeDiscount)
    {
        itemInfo = type;
        discount = Random.Range(storeDiscount.minDiscount, storeDiscount.maxDiscount);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemInfo.sprite;
        sr.sortingLayerName = "StoreObjectsInterior";

    }

    public void Interact(GameObject player)
    {
        if (interactable)
        {
            PlayerInteracter playerIter = player.GetComponent<PlayerInteracter>();

            playerIter.SetItem(this); //give the player the item info

            GetComponent<SpriteRenderer>().enabled = false; //make the item disapear
            interactable = false;
            CloseDisplay();
        }
    }

    public void DisplayItemInfo()
    {
        GetComponentInChildren<Canvas>().enabled = true;
    }

    public void CloseDisplay()
    {
        GetComponentInChildren<Canvas>().enabled = false;
    }
}
