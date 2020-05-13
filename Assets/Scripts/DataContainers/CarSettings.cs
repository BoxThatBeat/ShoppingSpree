using UnityEngine;

[CreateAssetMenu(menuName = "CarSettings")]
public class CarSettings : ScriptableObject
{
    public float maxVelocity;
    public float accel;
    public float startVelocity;
    public float minStopVelocity;
}
