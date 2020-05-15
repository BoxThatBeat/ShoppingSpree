using TMPro;
using System.Collections;
using UnityEngine;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI money;

    public TextMeshProUGUI moneyLoss;
    public int player;
    public string typeUI;

    //for animations:
    public float startPosX;
    public LeanTweenType easeTypeMoney;
    public LeanTweenType easeTypeScore;

    private int difference;

    private void OnEnable()
    {
        EventSystemUI.current.onMoneyChanged += ChangeMoney;
    }
    private void OnDisable()
    {
        EventSystemUI.current.onMoneyChanged -= ChangeMoney;
    }

    private void Start()
    {
        money = GetComponent<TextMeshProUGUI>();
        moneyLoss.enabled = false;
    }

    private void ChangeMoney(string type, int playerId, int amount)
    {

        if (player == playerId && typeUI == type)
        {
            if (typeUI == "Money")
                difference = int.Parse(money.text.Substring(1)) - amount; //removes the dollar sign and gets the integer value to find the diff
            else if (typeUI == "Score")
                difference = amount - int.Parse(money.text.Substring(1));

            if (difference > 0)//if there is a negative difference between the old momeny and the new then show in the negative UI
            {
                
                if (typeUI == "Money")
                {
                    moneyLoss.enabled = true;
                    moneyLoss.text = "-$" + difference.ToString();
                    LeanTween.moveLocalX(moneyLoss.gameObject, -10f, 0.5f).setEase(easeTypeMoney).setOnComplete(ResetGUI); //animate GUI
                }  
                else if (typeUI == "Score")
                {
                    moneyLoss.enabled = true;
                    moneyLoss.text = "+$" + difference.ToString();
                    LeanTween.moveX(moneyLoss.gameObject, 1f, 0.5f).setEase(easeTypeScore).setOnComplete(ResetGUI);
                }
            }

            money.text = "$" + amount.ToString(); //update the money UI with the new amount
        }
    }

    private void ResetGUI()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.moveX(moneyLoss.GetComponent<RectTransform>(), startPosX, 0.2f);
        yield return new WaitForSeconds(0.2f);
        moneyLoss.enabled = false;
    }
}


