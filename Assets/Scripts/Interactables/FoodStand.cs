using UnityEngine;
using System;

public class FoodStand : MonoBehaviour, IInteractable
{
    [SerializeField] private int minPrice;
    [SerializeField] private int maxPrice;
    [SerializeField] private int price;
    [SerializeField] private int addedStamina;

    private void Start()
    {
        price = UnityEngine.Random.Range(minPrice, maxPrice);
    }
    public void Interact(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.SubtractMoney(price); //charge the player for food
        playerController.AddStamina(addedStamina);
    }
    public void DisplayItemInfo()
    {
        Debug.Log("foodstand display");
    }

    public void CloseDisplay()
    {
        Debug.Log("closed display");
    }
}