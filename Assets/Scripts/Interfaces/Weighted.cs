using UnityEngine;

public abstract class Weighted : ScriptableObject
{
    public int weight;

    //Function that picks an item from items that have a weight attribute. The higher the weight, the more likley to be picked
    public static Weighted WeightedPick(Weighted[] items)
    {
        int totalWeight = 0;

        for (int i = 0; i < items.Length; i++)
        {
            totalWeight += items[i].weight;
        }

        int rndNum = Random.Range(0, totalWeight); //if total weight was 100 then if it picked 99 it would go through all other objects until the one with weight 1

        foreach (Weighted item in items)
        {
            if (rndNum < item.weight)
            {
                return item;
            }
            rndNum -= item.weight;
        }

        Debug.LogError("weighted select did not find an item");
        return null; //should never occur
    }
}
