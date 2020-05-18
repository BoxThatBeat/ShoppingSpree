using UnityEngine;

[CreateAssetMenu(menuName ="PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float blockTimeToHospital;
    public float blockTimeToStore;
    public float knockOutFadeTime;
    public int startMoney;
}
