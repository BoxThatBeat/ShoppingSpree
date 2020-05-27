using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : Weighted
{
    public Store store;
    public Sprite sprite;
    public int price;
    
}
