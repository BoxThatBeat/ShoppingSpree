using System;
using UnityEngine;

public class EventSystemGame : MonoBehaviour
{
    public static EventSystemGame current;

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

    public event Action onGameOver;
    public void GameOver()
    {
        onGameOver?.Invoke();
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

    public event Action<int, bool> onPlayerRunStateChanged;
    public void PlayerRunning(int id, bool value)
    {
        onPlayerRunStateChanged?.Invoke(id, value);
    }
}