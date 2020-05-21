using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiscountName
{
    Common, Exceptioonal, Unique, Rare
}

[CreateAssetMenu(menuName = "Discount")]
public class Discount : ScriptableObject
{
    public Sprite sign;
    public DiscountName discountName;
    public int minDiscount;
    public int maxDiscount;
}
