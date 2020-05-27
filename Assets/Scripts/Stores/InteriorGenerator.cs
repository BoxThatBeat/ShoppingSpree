using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorGenerator : MonoBehaviour
{
    public StoreType type;
    public Discount discount;

    [SerializeField] private Transform[] itemSpawnPositions;
    [SerializeField] private GameObject itemPrefab;

    public void GenerateItems()
    {
        Debug.Log("Generating items with type" + type.storeName);
    }
}
