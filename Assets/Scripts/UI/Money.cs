using TMPro;
using System.Collections;
using UnityEngine;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI money;
    public TextMeshProUGUI moneyLoss;
    public int player;
    public float startPosX;

    //for animations:
    public LeanTweenType easeTypeMoney;

    private int difference;
    private bool moneyAnimReady = true;

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

    private void ChangeMoney(int playerId, int amount)
    {

        if (player == playerId)
        {
            difference = int.Parse(money.text.Substring(1)) - amount; //removes the dollar sign and gets the integer value to find the diff

            if (difference > 0 && moneyAnimReady)//if there is a negative difference between the old money and the new then show in the negative UI
            {
                moneyAnimReady = false;

                moneyLoss.enabled = true;
                moneyLoss.text = "-$" + difference.ToString();
                LeanTween.moveLocalX(moneyLoss.gameObject, -10f, 0.5f).setEase(easeTypeMoney).setOnComplete(ResetGUI); //animate GUI
            }

            money.text = "$" + amount.ToString(); //update the money UI with the new amount
        }
    }

    private void ResetGUI()
    {
        StartCoroutine(ResetMoney());
    }

    private IEnumerator ResetMoney()
    {
        yield return new WaitForSeconds(1f);

        LeanTween.moveX(moneyLoss.GetComponent<RectTransform>(), startPosX, 0.2f);

        yield return new WaitForSeconds(0.2f);
        moneyLoss.enabled = false;
        moneyAnimReady = true;
    }
}


