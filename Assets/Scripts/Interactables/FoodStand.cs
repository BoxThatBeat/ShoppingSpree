using UnityEngine;

public class FoodStand : MonoBehaviour, IInteractable
{
    [SerializeField] private int minPrice;
    [SerializeField] private int maxPrice;
    [SerializeField] private int addedStamina;

    private int price;

    private void Start()
    {
        price = UnityEngine.Random.Range(minPrice, maxPrice);
    }
    public void Interact(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        
        if (playerController.money - price >= 0 && playerController.stamina != playerController.attributes.maxStamina)
        {
            playerController.SubtractMoney(price); //charge the player for food
            playerController.AddStamina(addedStamina);
        }
    }
    public void OpenDisplay()
    {
        Debug.Log("foodstand display");
        //GetComponentInChildren<Canvas>().enabled = true;
    }

    public void CloseDisplay()
    {
        Debug.Log("closed display");
    }
}