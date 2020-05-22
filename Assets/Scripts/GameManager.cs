using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int gameTimer = 600; //10 minutes in seconds 
    private bool canDropTimer = true;
    private bool gameStarted = false;
    private bool lightsAreOn = false;

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
        gameTimer -= 30; //SET TO 1 WHEN DONE TESTING
        EventSystemUI.current.ChangeTimeUI(gameTimer);//update the timer UI
        EventSystemGame.current.LowerSun(gameTimer);//send a percentage of the game time to change the sun color

        if (gameTimer <= 210 && !lightsAreOn)
        {
            lightsAreOn = true;
            EventSystemGame.current.TurnLightsOn();
        }

        canDropTimer = true;
    }

    public IEnumerator LoadCity() //load city with the fade effect
    {
        EventSystemGame.current.FadePlayer(1, 0.8f);
        EventSystemGame.current.FadePlayer(2, 0.8f);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("City");
        gameStarted = true;

        
    }

}
