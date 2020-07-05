using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject CharacterSelect;

    public GameObject masterVolumeSlider;
    public GameObject soundVolumeSlider;
    public GameObject musicVolumeSlider;

    public GameObject UIMenuFirstSelected;
    public GameObject UIOptionsFirstSelected;
    public GameObject UICharacterFirstSelected;

    public EventSystem eventSystem;

    public void QuitBtn()
    {
        GameManager.Instance.QuitGame();
    }

    public void SwitchToOptions()
    {
        //set the values of the sliders to be what the actual volumes are at
        masterVolumeSlider.GetComponent<Slider>().value = AudioManager.Instance.masterVolume;
        soundVolumeSlider.GetComponent<Slider>().value = AudioManager.Instance.soundVolume;
        musicVolumeSlider.GetComponent<Slider>().value = AudioManager.Instance.musicVolume;

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

    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen; //toggle fullscreen
    }

    public void StartBtn()
    {
        GameManager.Instance.StartCoroutine("LoadCity");
    }

    //menu volume sliders reference these functions
    public void ChangeMasterVolume(float newVolume) { EventSystemGame.current.ChangeVolume(0, newVolume); }
    public void ChangeSoundVolume(float newVolume) { EventSystemGame.current.ChangeVolume(1, newVolume); }
    public void ChangeMusicVolume(float newVolume) { EventSystemGame.current.ChangeVolume(2, newVolume); }
}
