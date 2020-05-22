using System;
using UnityEngine;

public class EventSystemGame : MonoBehaviour
{
    public static EventSystemGame current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int, float> onFadeEffect;
    public void FadePlayer(int id, float speed)
    {
        onFadeEffect?.Invoke(id, speed);
    }

    public event Action onLightsOn;
    public void TurnLightsOn()
    {
        onLightsOn?.Invoke();
    }

    public event Action<int> onSunLower;
    public void LowerSun(int time)
    {
        onSunLower?.Invoke(time);
    }

}