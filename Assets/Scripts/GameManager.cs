﻿using UnityEngine;
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

    public void SetUsingControllers(bool value) //swap value everytime this is called
    {
        gameSettings.usingControllers = value;
    }

    public bool GetUsingControllers()
    {
        return gameSettings.usingControllers;
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
        lightsAreOn = false;
        canDropTimer = true;

        gameTimer = 600;
        bonusItemReward = 150;
    }

    public void LoadMainMenu() //load city with the fade effect
    {
        SceneManager.LoadScene("MainMenu");
        ResetGame();
    }

    public void LoadCity()
    {
        EventSystemGame.current.FadePlayer(1, 0.8f);
        EventSystemGame.current.FadePlayer(2, 0.8f);
        SceneManager.LoadScene("City");
        gameStarted = true;
    }

    private IEnumerator CountDown()
    {
        canDropTimer = false;
        yield return new WaitForSecondsRealtime(1f);

        if (!GameIsPaused)
        {
            gameTimer -= 30;//CHANGE WHEN DONE TESTING
            EventSystemUI.current.ChangeTimeUI(gameTimer);//update the timer UI
            EventSystemGame.current.LowerSun(gameTimer);//send a percentage of the game time to change the sun color

            canDropTimer = true;
        }
    }

    private IEnumerator IncreaseBonusReward()
    {
        canIncreaseReward = false;
        yield return new WaitForSecondsRealtime(10f);

        if (!GameIsPaused)
        {
            bonusItemReward += 10; //increase bonus item reward by $10 every 10 seconds
            EventSystemUI.current.ChangeBonusReward(bonusItemReward);
            canIncreaseReward = true;
        }
    }

    /*
    public IEnumerator LoadCity() //load city with the fade effect
    {
        EventSystemGame.current.FadePlayer(1, 0.8f);
        EventSystemGame.current.FadePlayer(2, 0.8f);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("City");
        gameStarted = true;
    }

    */
}
