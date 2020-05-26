using UnityEngine;

public class CashRegister : MonoBehaviour, IInteractable
{

    public void Interact(GameObject player)
    {
        player.GetComponentInChildren<IconBox>().Close();//close the icon bubble

        player.GetComponent<PlayerController>().SubtractMoney(player.GetComponent<PlayerInteracter>().heldItem.price); //charge the player

        player.GetComponent<PlayerInteracter>().heldItem = null;
    }
}
