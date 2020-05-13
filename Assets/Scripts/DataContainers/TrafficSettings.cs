using UnityEngine;

[CreateAssetMenu(menuName = "TrafficSettings")]
public class TrafficSettings : ScriptableObject
{
    public float transitionPeriod;
    public float yellowTime;
    public float letGoTime;
}
