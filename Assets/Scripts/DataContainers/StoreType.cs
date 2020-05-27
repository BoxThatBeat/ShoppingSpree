using UnityEngine;
public enum Store
{
    Jewellery, Clothing, Bookstore, Flowershop, Equipement, Auto, Computer
}
[CreateAssetMenu(menuName ="Store")]
public class StoreType : Weighted
{
    public Weighted[] items;
    public Sprite logo;
    public Store storeName;
}
