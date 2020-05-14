using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int gameTimer = 300; //5 minutes in seconds 
    private bool canDropTimer = true;
    private bool gameStarted = false;

    private void Awake() 
    {
        if (Instance == null)//makes the script a singleton
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (canDropTimer && gameStarted)
            StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        canDropTimer = false;
        yield return new WaitForSecondsRealtime(1f);
        gameTimer -= 1;
        EventSystemUI.current.ChangeTimeUI(gameTimer);
        canDropTimer = true;
    }

    public IEnumerator LoadCity() //load city with the fade effect
    {
        float fadeTime = gameObject.GetComponent<FadeEffect>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("City");
        gameStarted = true;
    }

    /*
    public IEnumerator Blackout() //Black out the screen and fade back in
    {
        gameObject.GetComponent<FadeEffect>().alpha = 1;
        float fadeTime = gameObject.GetComponent<FadeEffect>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
    }

    // Shows the money loss
    IEnumerator ShowLoss(string loss, float delay)
    {
        loseMoneyText.text = "-$" + loss;
        loseMoneyText.enabled = true;
        yield return new WaitForSeconds(delay);
        StartCoroutine(FadeOut()); // FadeOut function
        yield return new WaitForSeconds(delay);
        loseMoneyText.enabled = false;
    }

    // Fades the text for the money loss
    IEnumerator FadeOut()
    {
        float startAlpha = loseMoneyText.color.a;

        float rate = 1.0f / 1.33f;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tempColor = loseMoneyText.color;

            loseMoneyText.color = new Color(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(startAlpha, 0, progress));

            progress += rate * Time.deltaTime;

            yield return null;
        }
    }

    private void Update()
    {
        // Updates the user's money (note: if we have methods for adding/subtracting money, it would be ideal to place this in each of those)
        moneyText.text = "$" + money.ToString();

        gameTimer -= 1f;

        int minutes = (int)(gameTimer % 60);
        int hours = (int)(gameTimer / 60);

        string timerString = string.Format("{0:00}:{1:00}", hours, minutes);

        timeText.text = timerString;
    }

    
    private void OnLevelWasLoaded()
    {
        StopPlayer = false; //let the player move again
    }
    */


}
