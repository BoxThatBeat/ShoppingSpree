using UnityEngine;
using UnityEngine.UI;

public class BonusItems : MonoBehaviour
{
    [SerializeField] private Stores storeArray = null;

    private Image[] images;
    private Item[] currentBonusItems;

    private int storeIndex = 0;
    private int itemIndex = 0;
    private int numItemsInitiated = 0;

    private bool switchStore = false;

    private void Awake()
    {
        currentBonusItems = new Item[9]; //create array of Items to be bonus items

        EventSystemUI.current.onBonusItemBought += EliminateBonusItem;
        EventSystemGame.current.onAddBonusItem += AddBonusItems;

        foreach (StoreType store in storeArray.stores)
        {
            Weighted[] items = store.items;

            foreach (Item item in items)
            {
                item.bonusItemIndex = -1; //make sure all items are not bonus items at start since assets keep their state throughout scene changes
            }
        }
    }

    private void Start()
    {
        images = GetComponentsInChildren<Image>();
    }

    private void AddBonusItems()
    {
        if (storeIndex < storeArray.stores.Length && numItemsInitiated <= 9)
        {
            Weighted[] items = storeArray.stores[storeIndex].items; //get the list of items in each store

            if (switchStore) //switch store every second bonus Item
            {
                ++storeIndex;
                switchStore = false;
            }
            else
            {
                switchStore = true;
            }
                

            if (items.Length >= 2)
            {
                AddRandomItemToBonusList(items, itemIndex++);
                ++numItemsInitiated;
            }
        }
    }


    private void AddRandomItemToBonusList(Weighted[] items, int index)
    {
        int randItemIndex = Random.Range(0, items.Length);
        Item item = (Item)items[randItemIndex];

        images[index].enabled = true;
        images[index].sprite = item.sprite;
        item.bonusItemIndex = index;

        currentBonusItems[index] = item; //add the item to a local list of items that are selected bonus items
    }

    private void EliminateBonusItem(int playerId, int itemId)
    {

        currentBonusItems[itemId].bonusItemIndex = -1; //makes all of the items that use this asset not give bonus points anymore
    }

    private void OnDisable()
    {
        EventSystemUI.current.onBonusItemBought -= EliminateBonusItem;
        EventSystemGame.current.onAddBonusItem -= AddBonusItems;
    }
}
