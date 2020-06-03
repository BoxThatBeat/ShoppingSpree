using UnityEngine;
using TMPro;

public class Atm : MonoBehaviour, IInteractable
{
    private IconBox display;
    [SerializeField] private TextMeshProUGUI moneyInBank;

    private void Start()
    {
        display = GetComponentInChildren<IconBox>();
    }

    public void Interact(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        
        if (playerController.money < playerController.attributes.pocketSize && playerController.moneyInBank > 0)
        {
            int exchange = playerController.attributes.pocketSize - playerController.money;

            if (exchange > playerController.moneyInBank)
            {
                playerController.AddMoney(playerController.moneyInBank);
                playerController.moneyInBank = 0;
            }
            else
            {
                playerController.AddMoney(exchange);
                playerController.moneyInBank = playerController.moneyInBank - exchange;
            }
        }

        SetMoneyInBank(playerController.moneyInBank);
    }

    private void SetMoneyInBank(int amount)
    {
        moneyInBank.text = amount.ToString();
    }

    public void OpenDisplay(GameObject player)
    {
        SetMoneyInBank(player.GetComponent<PlayerController>().moneyInBank);
        display.SetIcon(null);//open display
    }

    public void CloseDisplay()
    {
        display.Close();
    }
}