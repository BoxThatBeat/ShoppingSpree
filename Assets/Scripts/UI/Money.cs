using TMPro;
using System.Collections;
using UnityEngine;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI money;
    public TextMeshProUGUI moneyLoss;
    public int player;
    public string typeUI;

    private int difference;

    private void Start()
    {
        EventSystemUI.current.onMoneyChanged += ChangeMoney;
        money = GetComponent<TextMeshProUGUI>();
        moneyLoss.enabled = false;
    }

    private void ChangeMoney(string type, int playerId, int amount)
    {

        if (player == playerId && typeUI == type)
        {
            if (typeUI == "Money")
                difference = int.Parse(money.text.Substring(1)) - amount; //removes the dollar sign and gets the integer value to find the diff
            else
                difference = amount - int.Parse(money.text.Substring(1));

            if (difference > 0) //if there is a negative difference between the old momeny and the new then show in the negative UI
                StartCoroutine(ShowDiff(difference, 2f));

            money.text = "$" + amount.ToString(); //update the money UI with the new amount
        }
    }

    private IEnumerator ShowDiff(int diff, float delay)
    {
        if (typeUI == "Money")
            moneyLoss.text = "-$" + diff.ToString();
        else if (typeUI == "Score")
            moneyLoss.text = "+$" + diff.ToString();
        moneyLoss.enabled = true;
        yield return new WaitForSeconds(delay);
        moneyLoss.enabled = false;
    }

}


