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
    public event Action<int> onMoneySubtracted;
    public void SubtractMoney(int id)
    {
        onMoneySubtracted?.Invoke(id);
    }
    public event Action<int> onScoreAdded;
    public void AddScore(int id)
    {
        onScoreAdded?.Invoke(id);
    }
    public event Action<int> onTimeChanged;
    public void ChangeTime(int time)
    {
        onTimeChanged?.Invoke(time);
    }

}
