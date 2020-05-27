using UnityEngine;

[CreateAssetMenu(menuName = "Discount")]
public class Discount : Weighted
{
    public Sprite sign;
    public int minDiscount;
    public int maxDiscount;
}
