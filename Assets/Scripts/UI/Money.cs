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

    private void OnDisable()
    {
        EventSystemUI.current.onMoneyChanged -= ChangeMoney;
    }

    /*
    // Fades the text for the money loss
    IEnumerator FadeOut()
    {
        float startAlpha = loseMoneyText.color.a;

        float rate = 1.0f / 1.33f;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tempColor = loseMoneyText.color;

            loseMoneyText.color = new Color(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(startAlpha, 0, progress));

            progress += rate * Time.deltaTime;

            yield return null;
        }
    }
    */
}


