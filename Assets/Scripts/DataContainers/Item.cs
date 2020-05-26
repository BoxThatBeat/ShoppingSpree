using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public Store store;
    public Sprite sprite;
    public int price;
}
