using UnityEngine;

public enum StoreName
{
    Jewellery,Clothing,Equipement,Auto,Computer
}

[CreateAssetMenu(menuName ="Store")]
public class Store : ScriptableObject
{
    public Sprite logo;
    public StoreName storeName;
    public int minPrice;
    public int maxPrice;
}
