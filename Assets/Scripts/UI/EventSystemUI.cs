using System;
using UnityEngine;

public class EventSystemUI : MonoBehaviour
{
    public static EventSystemUI current;

    private void Awake()
    {
        current = this;
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

    public event Action<int> onTimeChanged;
    public void ChangeTimeUI(int time)
    {
        onTimeChanged?.Invoke(time);
    }

}
