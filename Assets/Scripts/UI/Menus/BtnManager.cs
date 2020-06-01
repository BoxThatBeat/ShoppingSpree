using UnityEngine;
using UnityEngine.EventSystems;

public class BtnManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject CharacterSelect;

    public GameObject UIMenuFirstSelected;
    public GameObject UIOptionsFirstSelected;
    public GameObject UICharacterFirstSelected;

    public EventSystem eventSystem;


    public void QuitBtn()
    {
        Application.Quit();
    }

    public void SwitchToOptions()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);

        eventSystem.SetSelectedGameObject(UIOptionsFirstSelected);
    }

    public void SwitchToMainMenu()
    {
        CharacterSelect.SetActive(false);
        Options.SetActive(false);
        MainMenu.SetActive(true);

        eventSystem.SetSelectedGameObject(UIMenuFirstSelected);
    }

    public void SwitchToCharacterSelect()
    {
        MainMenu.SetActive(false);
        CharacterSelect.SetActive(true);

        eventSystem.SetSelectedGameObject(UICharacterFirstSelected);
    }

    public void StartBtn()
    {
        GameManager.Instance.StartCoroutine("LoadCity");
    }
}
