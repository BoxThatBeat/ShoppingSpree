using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject player);

    void OpenDisplay();
    void CloseDisplay();
}
