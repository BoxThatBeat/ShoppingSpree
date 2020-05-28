using UnityEngine;

[CreateAssetMenu(menuName = "Settings/CharacterAttributes")]
public class CharacterAttributes : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float knockOutFadeTime;
    public float maxStamina;
    public int startMoney;
    
}
