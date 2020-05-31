using System;
using UnityEngine;

public class InteriorGenerator : MonoBehaviour
{
    [NonSerialized] public StoreType store;
    [NonSerialized] public Discount discount;

    [SerializeField] private Transform itemSpawnPositions = null;
    [SerializeField] private ItemController itemPrefab = null;

    public void GenerateItems()
    {
        if (store.items.Length != 0)
        {
            //go through all the item spawn points in the transforms children, to instantiate the prefab and the set its properties using InitItem
            for (int i = 0; i < itemSpawnPositions.childCount; i++)
            {
                ItemController item = Instantiate(itemPrefab, itemSpawnPositions.GetChild(i).position, transform.rotation);

                item.InitItem((Item)Weighted.WeightedPick(store.items), discount); //set the item's data to a randomly (weighted) pick from the items available to spawn in the store
            }
        }
    }
}
