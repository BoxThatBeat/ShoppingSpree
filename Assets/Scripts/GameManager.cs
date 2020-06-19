using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool GameIsPaused = false;

    public int bonusItemReward { get; private set; }
    private bool canIncreaseReward = true;

    private int gameTimer = 600; //10 minutes in seconds 
    private bool canDropTimer = true;

    private bool gameStarted = false;
    private bool lightsAreOn = false;

    public characters playerOneCharacter;
    public characters playerTwoCharacter;

    public Settings gameSettings;


    private void Awake() 
    {

        if (Instance == null)//makes the script a singleton
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        EventSystemGame.current.FadePlayer(1, 1.5f);
        EventSystemGame.current.FadePlayer(2, 1.5f);//fade this start of the mainmenu loading

        bonusItemReward = 150; //start bonus amount at 150

        //init leantween
        LeanTween.init(800);
    }

    private void Update()
    {

        if (gameStarted && !GameIsPaused)
        {
            if (canDropTimer)
                StartCoroutine(CountDown());

            if (canIncreaseReward)
                StartCoroutine(IncreaseBonusReward());

            if (gameTimer <= 210 && !lightsAreOn)
            {
                lightsAreOn = true;
                EventSystemGame.current.TurnLightsOn();
            }

            if (gameTimer <= 0)
            {
                EventSystemGame.current.GameOver(); //call the gameover event
                EventSystemGame.current.PlaySound("GameOver");
                LeanTween.pauseAll();
                gameStarted = false;
            }

            
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ResetGame()
    {
        gameStarted = false;
        canIncreaseReward = true;
        canDropTimer = true;
        lightsAreOn = false;

        LeanTween.resumeAll();

        gameTimer = 600;
        bonusItemReward = 150;
    }

    public void LoadMainMenu() //load city with the fade effect
    {
        EventSystemGame.current.FadePlayer(1, 1.5f);
        EventSystemGame.current.FadePlayer(2, 1.5f);
        SceneManager.LoadScene("MainMenu");
        gameStarted = false;
    }

    public void LoadCity()
    {
        ResetGame();
        EventSystemGame.current.FadePlayer(1, 0.8f);
        EventSystemGame.current.FadePlayer(2, 0.8f);
        SceneManager.LoadScene("City");
        StartCoroutine(WaitForStartOfGame());
    }


    private IEnumerator WaitForStartOfGame()
    {
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        EventSystemGame.current.AddBonusItem();
        EventSystemGame.current.PlaySound("Music");
    }

    private IEnumerator CountDown()
    {
        canDropTimer = false;
        yield return new WaitForSecondsRealtime(1f);

        
        if (!GameIsPaused)
        {
            gameTimer -= 1;
            EventSystemUI.current.ChangeTimeUI(gameTimer);//update the timer UI
            EventSystemGame.current.LowerSun(gameTimer);//send a percentage of the game time to change the sun color

            if (gameTimer % 60 == 0)//every 2 minutes (called here to not call multiple times every frame at 60 seconds)
            {
                EventSystemGame.current.AddBonusItem();
                //play sound effect
            }
            if (gameTimer <= 10 && gameTimer > 0) //last ten seconds
            {
                EventSystemGame.current.PlaySound("CountDown");
            }
        }

        canDropTimer = true;
    }

    private IEnumerator IncreaseBonusReward()
    {
        canIncreaseReward = false;
        yield return new WaitForSecondsRealtime(10f);

        if (!GameIsPaused)
        {
            bonusItemReward += 5; //increase bonus item reward by $5 every 10 seconds
            EventSystemUI.current.ChangeBonusReward(bonusItemReward);
        }

        canIncreaseReward = true;
    }
}
