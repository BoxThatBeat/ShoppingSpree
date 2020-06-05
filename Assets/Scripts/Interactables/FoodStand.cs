using UnityEngine;
using TMPro;

public class FoodStand : MonoBehaviour, IInteractable
{
    [SerializeField] private int addedStamina = 0;
    [SerializeField] private int price = 0;
    private IconBox display;
    private TextMeshProUGUI priceText;

    private void Start()
    {
        priceText = GetComponentInChildren<TextMeshProUGUI>();
        display = GetComponentInChildren<IconBox>();

        priceText.text = price.ToString();
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
    public void OpenDisplay(GameObject player)
    {
        display.SetIcon(null);//open display
    }

    public void CloseDisplay()
    {
        display.Close();
    }
}