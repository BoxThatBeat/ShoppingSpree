using UnityEngine;

[CreateAssetMenu(menuName = "Settings/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float storeFadeTime;
    public float blockTimeToStore;
    public float staminaDecreaseInterval;
    public int hospitalCost;
}

