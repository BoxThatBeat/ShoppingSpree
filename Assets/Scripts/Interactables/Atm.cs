using UnityEngine;
using TMPro;

public class Atm : MonoBehaviour, IInteractable
{
    [SerializeField] private int addedStamina;
    [SerializeField] private int price;
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
    public void OpenDisplay()
    {
        display.SetIcon(null);//open display
    }

    public void CloseDisplay()
    {
        display.Close();
    }
}