using UnityEngine;
using UnityEngine.UI;

public class BonusItems : MonoBehaviour
{
    [SerializeField] private StoreType[] stores;

    private Image[] images;
    private Item[] currentBonusItems;

    private void Awake()
    {
        currentBonusItems = new Item[9];

        EventSystemUI.current.onBonusItemBought += EliminateBonusItem;

        foreach (StoreType store in stores)
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

        for (int i = 0; i < stores.Length; i++)
        {

            if (i == images.Length)
            {
                Debug.LogError("Too many stores to fit in bonus item UI");
                return;//stop if there are more stores than bonus items slots (future proofing)
            }

            Weighted[] items = stores[i].items; //get the list of items in each store

            if (items.Length != 0)
            {
                int randItemIndex = Random.Range(0, items.Length);
                Item item = (Item)items[randItemIndex];

                images[i].sprite = item.sprite;
                item.bonusItemIndex = i;

                currentBonusItems[i] = item; //add the item to a local list of items that are selected bonus items
            }
        }
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
