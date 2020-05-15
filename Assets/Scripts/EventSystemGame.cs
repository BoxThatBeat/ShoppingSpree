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
        Debug.Log("test");
        onFadeEffect?.Invoke(id, speed);
    }

}