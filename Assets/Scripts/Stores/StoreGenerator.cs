using UnityEngine;

/*
 * Class That generates all stores randomly to create a new city each game
 */
 
public class StoreGenerator : MonoBehaviour
{
    [SerializeField] private Stores storeArray = null;
    [SerializeField] private Weighted[] discounts = null;

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

            //Select the store type and store discount
            //cast the weighted to be storeType as it derives from Weigted and we dont need the weighted attribute after selecting the store type
            StoreType selectedStore = (StoreType)Weighted.WeightedPick(storeArray.stores);
            Discount selectedDiscount = (Discount)Weighted.WeightedPick(discounts);

            //set up store exterior by setting the sign sprites to the one stored in the StoreType asset
            SignEditor[] signs = newStore.GetComponentsInChildren<SignEditor>();
            foreach (SignEditor sign in signs)
            {
                //set the type of store sign
                if (sign.signType == SignTypes.store)
                {
                    sign.SetSprite(selectedStore.logo);
                }
                else if (sign.signType == SignTypes.sale)
                {
                    sign.SetSprite(selectedDiscount.sign);
                }
            }

            //set up the store interior by setting the type for the generation
            InteriorGenerator storeInterior = interiors[StoreId - 1].GetComponent<InteriorGenerator>();
            storeInterior.store = selectedStore;
            storeInterior.discount = selectedDiscount;
            storeInterior.GenerateItems();

            storeDoor.storeId = StoreId++; //after setting the storeId post-increment the static variable for the next store
        }
    }
}
