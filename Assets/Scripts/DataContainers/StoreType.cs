using UnityEngine;
public enum Store
{
    Jewellery, Clothing, Bookstore, Flowershop, Equipement, Auto, Computer
}
[CreateAssetMenu(menuName ="Store")]
public class StoreType : ScriptableObject
{
    public Sprite logo;
    public Store storeName;
    public int minPrice;
    public int maxPrice;
}
