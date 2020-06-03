using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject player);

    void OpenDisplay(GameObject player);
    void CloseDisplay();
}
