using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchSelectedButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = GetComponent<EventSystem>();
        EventSystemGame.current.onGameOver += SwitchSelected;
    }

    private void SwitchSelected()
    {
        eventSystem.SetSelectedGameObject(button);
    }

    private void OnDestroy()
    {
        EventSystemGame.current.onGameOver -= SwitchSelected;
    }
}
