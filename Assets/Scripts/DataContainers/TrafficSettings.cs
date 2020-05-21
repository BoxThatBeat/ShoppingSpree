using UnityEngine;

[CreateAssetMenu(menuName = "Settings/TrafficSettings")]
public class TrafficSettings : ScriptableObject
{
    public float transitionPeriod;
    public float yellowTime;
    public float ColliderMoveDistance;
}
