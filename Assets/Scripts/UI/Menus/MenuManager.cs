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

        //setup the link to the audiomanager control methods:
        SetSliderLink(masterVolumeSlider);
        SetSliderLink(soundVolumeSlider);
        SetSliderLink(musicVolumeSlider);

        MainMenu.SetActive(false);
        Options.SetActive(true);

        eventSystem.SetSelectedGameObject(UIOptionsFirstSelected);
    }

    private void SetSliderLink(GameObject slider)
    {
        //Get the event trigger attached to the UI object
        EventTrigger eventTrigger = slider.GetComponent<EventTrigger>();

        //Create a new entry. This entry will describe the kind of event we're looking for
        // and how to respond to it
        EventTrigger.Entry entry = new EventTrigger.Entry();

        //This event will respond to a drop event
        entry.eventID = EventTriggerType.EndDrag;

        //Create a new trigger to hold our callback methods
        entry.callback = new EventTrigger.TriggerEvent();

        //Create a new UnityAction, it contains our DropEventMethod delegate to respond to events
        UnityEngine.Events.UnityAction<BaseEventData> callback =
            new UnityEngine.Events.UnityAction<BaseEventData>(DropEventMethod);

        //Add our callback to the listeners
        entry.callback.AddListener(callback);

        //Add the EventTrigger entry to the event trigger component
        eventTrigger.triggers.Add(entry);
    }
    //Create an event delegate that will be used for creating methods that respond to events
    public delegate void EventDelegate(BaseEventData baseEvent);

    public void DropEventMethod(BaseEventData baseEvent)
    {
        Debug.Log(baseEvent.selectedObject.name + " triggered an event!");
        //baseEvent.selectedObject is the GameObject that triggered the event,
        // so we can access its components, destroy it, or do whatever.
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
}
