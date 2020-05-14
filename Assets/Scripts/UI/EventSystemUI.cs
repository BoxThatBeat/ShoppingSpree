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
    public event Action<string,int,int> onMoneyChanged;
    public void ChangeMoneyUI(string type, int id,int amount)
    {
        onMoneyChanged?.Invoke(type, id, amount);
    }

    public event Action<int> onTimeChanged;
    public void ChangeTimeUI(int time)
    {
        onTimeChanged?.Invoke(time);
    }

}
