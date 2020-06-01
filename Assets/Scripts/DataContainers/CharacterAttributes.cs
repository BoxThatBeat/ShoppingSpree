using UnityEngine;

[CreateAssetMenu(menuName = "Settings/CharacterAttributes")]
public class CharacterAttributes : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float knockOutFadeSpeed;
    public float maxStamina;
    public int startMoney;

    public characters characterName;
    public string menuName;
    public string speedUI;
    public string moneyUI;
    public string specialUI;
    public Sprite menuArt;
    
}
