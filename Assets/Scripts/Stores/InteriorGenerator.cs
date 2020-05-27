using UnityEngine;

public class InteriorGenerator : MonoBehaviour
{
    public StoreType store;
    public Discount discount;

    [SerializeField] private Transform[] itemSpawnPositions = null;
    [SerializeField] private ItemController itemPrefab = null;

    public void GenerateItems()
    {
        Debug.Log("Generating items with type" + store.storeName);

        foreach(Transform spawn in itemSpawnPositions)
        {
            ItemController item = Instantiate(itemPrefab, spawn.position, transform.rotation);
            item.InitItem( (Item)Weighted.WeightedPick(store.items) ); //set the item's data to a randomly (weighted) pick from the items available to spawn in the store
        }
    }
}
