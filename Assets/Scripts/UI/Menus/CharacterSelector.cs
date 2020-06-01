using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterAttributes[] characters;
    [SerializeField] private int player;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterSpeed;
    [SerializeField] private TextMeshProUGUI characterWealth;
    [SerializeField] private TextMeshProUGUI characterSpecial;

    private Image characterArt;
    public int selectedCharacter = 0;
    

    private void Start()
    {
        characterArt = GetComponentInChildren<Image>();

        SetCharacter(characters[selectedCharacter]);
    }

    private void SetCharacter(CharacterAttributes character)
    {
        characterArt.sprite = character.menuArt;

        characterName.text = character.menuName;
        characterSpeed.text = "Speed: " + character.speedUI + "/5";
        characterWealth.text = "Wealth: " + character.moneyUI + "/5";
        characterSpecial.text = "Special: " + character.specialUI;

    }

    public void MoveSlectionRight()
    {
        if (selectedCharacter + 1 < characters.Length)
        {
            SetCharacter(characters[++selectedCharacter]);
        }
    }

    public void MoveSlectionLeft()
    {
        if (selectedCharacter - 1 >= 0)
        {
            SetCharacter(characters[--selectedCharacter]);
        }
    }

    public void FinalizeChoice()
    {
        if (player == 1)
            GameManager.Instance.playerOneCharacter = characters[selectedCharacter].characterName;
        else
            GameManager.Instance.playerTwoCharacter = characters[selectedCharacter].characterName;

    }
}
