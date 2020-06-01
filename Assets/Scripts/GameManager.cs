using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int bonusItemReward { get; private set; }
    private bool canIncreaseReward = true;

    private int gameTimer = 600; //10 minutes in seconds 
    private bool canDropTimer = true;

    private bool gameStarted = false;
    private bool lightsAreOn = false;

    public characters playerOneCharacter;
    public characters playerTwoCharacter;

    public Settings gameSettings;

    public void SetUsingControllers() //swap value everytime this is called
    {
        if (gameSettings.usingControllers)
            gameSettings.usingControllers = false;
        else
            gameSettings.usingControllers = true;
    }

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
        gameSettings.usingControllers = false; //default to not using controllers

        bonusItemReward = 150; //start bonus amount at 150

        /*
         * 
         * 
         * 
         * 
         * 
         */
        //REMOVE WHEN STARTING FROM MAINMENU
        //gameStarted = true;
    }

    private void Update()
    {
        if (gameStarted)
        {
            if (canDropTimer)
                StartCoroutine(CountDown());

            if (canIncreaseReward)
                StartCoroutine(IncreaseBonusReward());
        }
        
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

    private IEnumerator IncreaseBonusReward()
    {
        canIncreaseReward = false;
        yield return new WaitForSecondsRealtime(10f);

        bonusItemReward += 10; //increase bonus item reward by $10 every 10 seconds
        EventSystemUI.current.ChangeBonusReward(bonusItemReward);
        canIncreaseReward = true;
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
