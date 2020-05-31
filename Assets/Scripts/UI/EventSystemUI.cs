using System;
using UnityEngine;

public class EventSystemUI : MonoBehaviour
{
    public static EventSystemUI current;

    private void Awake()
    {

        if (current == null)//makes the script a singleton
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //define UI events that the UI scripts can subscribe to and that the gameObjects can notifty
    public event Action<int,int> onMoneyChanged;
    public void ChangeMoneyUI(int id,int amount)
    {
        onMoneyChanged?.Invoke(id, amount);
    }

    public event Action<int, int> onScoreChanged;
    public void ChangeScoreUI(int id, int amount)
    {
        onScoreChanged?.Invoke(id, amount);
    }

    public event Action<int,float> onStaminaChanged;
    public void ChangeStaminaUI(int id, float amount)
    {
        onStaminaChanged?.Invoke(id, amount);
    }

    public event Action<int, float> onSetMaxStamina;
    public void SetMaxStamina(int id, float amount)
    {
        onSetMaxStamina?.Invoke(id, amount);
    }

    public event Action<int> onTimeChanged;
    public void ChangeTimeUI(int time)
    {
        onTimeChanged?.Invoke(time);
    }

    public event Action<int> onBonusRewardChanged;
    public void ChangeBonusReward(int amount)
    {
        onBonusRewardChanged?.Invoke(amount);
    }

    public event Action<int,int> onBonusItemBought;
    public void BoughtBonusItem(int playerId, int itemId)
    {
        onBonusItemBought?.Invoke(playerId, itemId);
    }

}
