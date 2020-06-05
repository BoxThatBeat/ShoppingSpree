using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterAttributes[] characters = null;
    [SerializeField] private int player = 0;
    [SerializeField] private TextMeshProUGUI characterName = null;
    [SerializeField] private TextMeshProUGUI characterSpeed = null;
    [SerializeField] private TextMeshProUGUI characterWealth = null;
    [SerializeField] private TextMeshProUGUI characterSpecial = null;

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
