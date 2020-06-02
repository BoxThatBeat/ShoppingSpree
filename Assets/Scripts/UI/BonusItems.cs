using UnityEngine;
using UnityEngine.UI;

public class BonusItems : MonoBehaviour
{
    [SerializeField] private Stores storeArray;

    private Image[] images;
    private Item[] currentBonusItems;

    private void Awake()
    {
        currentBonusItems = new Item[9];

        EventSystemUI.current.onBonusItemBought += EliminateBonusItem;

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

        int storeIndex = 0;
        for (int i = 0; i < storeArray.stores.Length*2; i += 2)
        {

            if (i*2 == images.Length)
            {
                Debug.LogError("Too many stores to fit in bonus item UI");
                return;//stop if there are more stores than bonus items slots (future proofing)
            }

            Weighted[] items = storeArray.stores[storeIndex++].items; //get the list of items in each store

            if (items.Length >= 2)
            {
                AddRandomItemToBonusList(items, i);     //add two items from each shop
                AddRandomItemToBonusList(items, i + 1);
            }
        }
    }

    private void AddRandomItemToBonusList(Weighted[] items, int index)
    {
        int randItemIndex = Random.Range(0, items.Length);
        Item item = (Item)items[randItemIndex];

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
    }
}
