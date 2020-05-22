using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/*
 * Class That generates all stores randomly to create a new city each game
 * 
 * 
 */
public class StoreGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] smallStoreLocations = null;
    [SerializeField] private Transform[] mediumStoreLocations = null;
    [SerializeField] private Transform[] largeStoreLocations = null;

    [SerializeField] private GameObject[] smallStorePrefabs = null;
    [SerializeField] private GameObject[] mediumStorePrefabs = null;
    [SerializeField] private GameObject[] largeStorePrefabs = null;

    [SerializeField] private ExitStore[] interiors = null;
    //[SerializeField] private ExitStore[] mediumInteriors = null;
    //[SerializeField] private ExitStore[] largeInteriors = null;

    private int StoreId = 1;
    private void Start()
    {
        SpawnStores(smallStoreLocations, smallStorePrefabs, interiors);
        SpawnStores(mediumStoreLocations, mediumStorePrefabs, interiors);
        SpawnStores(largeStoreLocations, largeStorePrefabs, interiors);
    }

    private void SpawnStores(Transform[] locations, GameObject[] prefabs, ExitStore[] interiors)
    {
        for (int i = 0; i < locations.Length; i++)
        {
            
            GameObject newStore = Instantiate(prefabs[Random.Range(0, prefabs.Length)], locations[i].position, transform.rotation);

            //set up door connection between exteriors and interiors
            DoorController storeDoor = newStore.GetComponentInChildren<DoorController>();
            interiors[StoreId - 1].door = storeDoor.transform;
            storeDoor.storeId = StoreId++;

        }
    }

}
