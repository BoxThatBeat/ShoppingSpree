using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusReward : MonoBehaviour
{
    TextMeshProUGUI bonusRewardText = null;
    private void Start()
    {
        bonusRewardText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventSystemUI.current.onBonusRewardChanged += ChangeBonusRewardText;
    }
    private void OnDisable()
    {
        EventSystemUI.current.onBonusRewardChanged -= ChangeBonusRewardText;
    }

    private void ChangeBonusRewardText(int amount)
    {
        bonusRewardText.text = "$" + amount.ToString();
    }
}
