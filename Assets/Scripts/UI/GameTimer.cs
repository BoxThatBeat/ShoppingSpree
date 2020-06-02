using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private bool isRed;

    private void Start()
    {
        EventSystemUI.current.onTimeChanged += UpdateTimer;
        timer = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateTimer(int currentTimeInSeconds)
    {
        if (!isRed && currentTimeInSeconds <= 30)
        {
            timer.color = Color.red;
            isRed = true;
        }

        int minutes = (int)(currentTimeInSeconds % 60);
        int hours = (int)(currentTimeInSeconds / 60);

        string timerString = string.Format("{0:00}:{1:00}", hours, minutes);

        timer.text = timerString;
    }
}
