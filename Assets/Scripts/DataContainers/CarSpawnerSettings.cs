using UnityEngine;

[CreateAssetMenu(menuName = "Settings/CarSpawnerSettings")]
public class CarSpawnerSettings : ScriptableObject
{
    public float minTimeToSpawn;
    public float maxTimeToSpawn;
}
