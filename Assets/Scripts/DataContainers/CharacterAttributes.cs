using UnityEngine;

[CreateAssetMenu(menuName = "Settings/CharacterAttributes")]
public class CharacterAttributes : ScriptableObject
{
    [Header("Attributes for specific character:")]
    public float walkSpeed;
    public float runSpeed;
    public float knockOutFadeSpeed;
    public float maxStamina;
    public int pocketSize;
    public int maxMoneyInBank;

    [Space]
    [Header("Menu display information:")]
    public characters characterName;
    public string menuName;
    public string speedUI;
    public string moneyUI;
    public string specialUI;
    public Sprite menuArt;
    
}
