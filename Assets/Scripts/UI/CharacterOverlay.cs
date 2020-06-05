using UnityEngine;
using UnityEngine.UI;

public class CharacterOverlay : MonoBehaviour
{
    [SerializeField] private Sprite AaronIcon = null;
    [SerializeField] private Sprite JennaIcon = null;
    [SerializeField] private Sprite PDannyIcon = null;
    private Image[] overlays;

    void Start()
    {
        EventSystemUI.current.onBonusItemBought += SelectOverlay;
        overlays = GetComponentsInChildren<Image>();
    }

    private void SelectOverlay(int playerId, int itemId)
    {
        //add the player icon overtop item bought
        if (playerId == 1)
            OverlayIcon(GameManager.Instance.playerOneCharacter, itemId);
        else
            OverlayIcon(GameManager.Instance.playerTwoCharacter, itemId);

    }

    private void OverlayIcon(characters playerCharacter, int index)
    {
        overlays[index].color = new Color(255, 255, 255, 1); //set the alpha value to 1

        switch (playerCharacter)
        {
            case characters.aaron:
                overlays[index].sprite = AaronIcon;
                break;

            case characters.jen:
                overlays[index].sprite = JennaIcon;
                break;

            case characters.pdanny:
                overlays[index].sprite = PDannyIcon;
                break;
        }
    }

    private void OnDisable()
    {
        EventSystemUI.current.onBonusItemBought -= SelectOverlay;
    }
}
