using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player1;
    public GameObject playerOne;
    public CameraFollow Camera;

    public float gameTimer = 0.00f;
    public float money = 600.00f;
    public float value = 0.00f;
    public Text moneyText;
    public Text timeText;
    public Text loseMoneyText;

    public bool StopPlayer = false;

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

    public IEnumerator LoadCity() //load city with the fade effect
    {
        float fadeTime = gameObject.GetComponent<FadeEffect>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("City");
    }

    public void GameStart()
    {
        playerOne = Instantiate(player1, transform.position, Quaternion.identity);
        Camera.Target = playerOne;
    }
    public IEnumerator Blackout() //Black out the screen and fade back in
    {
        gameObject.GetComponent<FadeEffect>().alpha = 1;
        float fadeTime = gameObject.GetComponent<FadeEffect>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
    }

    private void Start()
    {
        
        loseMoneyText.enabled = false;
        moneyText.text = "$" + money.ToString();
    }

    public float getMoney()
    {
        return this.money;
    }

    public void setMoney(float change)
    {
        this.money += change;

        // Displays a loss in money if the user lost money
        if (change < 0)
        {
            StartCoroutine(ShowLoss(Mathf.Abs(change).ToString(), 1.33f));
        }

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

        gameTimer += Time.deltaTime;

        int minutes = (int)(gameTimer % 60);// (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 60);

        string timerString = string.Format("{0:00}:{1:00}", hours, minutes);

        timeText.text = timerString;
    }

    private void OnLevelWasLoaded()
    {
        StopPlayer = false; //let the player move again
    }



}
