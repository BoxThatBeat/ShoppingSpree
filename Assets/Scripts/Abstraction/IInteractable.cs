using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject player);

    void DisplayItemInfo();
    void CloseDisplay();
}
