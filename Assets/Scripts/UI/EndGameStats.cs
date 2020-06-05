using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameStats : MonoBehaviour
{
    [SerializeField] private GameObject endGameGUI = null;

    [SerializeField] private Canvas[] canvasesToBeTurnedOff = null;
    [SerializeField] private TextMeshProUGUI timeIsUp = null;
    [SerializeField] private TextMeshProUGUI playerWinner = null;
    [SerializeField] private TextMeshProUGUI playerOneScore = null;
    [SerializeField] private TextMeshProUGUI playerTwoScore = null;
    [SerializeField] private TextMeshProUGUI playerOneNumItems = null;
    [SerializeField] private TextMeshProUGUI playerTwoNumItems = null;
    [SerializeField] private float timeTillStatsShown = 1f;

    private int scoreOne;
    private int scoreTwo;

    private int numItemsBoughtOne;
    private int numItemsBoughtTwo;

    private void Start()
    {
        EventSystemGame.current.onGameOver += ShowTimeIsUp;
        EventSystemGame.current.onStatsSent += StoreStats;
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }

    public void RestartGame()
    {
        GameManager.Instance.LoadCity();
    }

    private void StoreStats(int playerId, int score, int numItemsBought)
    {
        if (playerId == 1)
        {
            scoreOne = score;
            numItemsBoughtOne = numItemsBought;
        }
        else
        {
            scoreTwo = score;
            numItemsBoughtTwo = numItemsBought;
        }
    }
    private void ShowTimeIsUp()
    {
        

        timeIsUp.enabled = true;

        foreach (Canvas canvas in canvasesToBeTurnedOff)
        {
            canvas.enabled = false;
        }

        StartCoroutine(ShowStats());
    }

    private IEnumerator ShowStats()
    {
        yield return new WaitForSeconds(timeTillStatsShown);

        timeIsUp.enabled = false;
        endGameGUI.SetActive(true);

        //show stats that are stored
        playerOneScore.text = "Score: " + scoreOne.ToString();
        playerTwoScore.text = "Score: " + scoreTwo.ToString();
        playerOneNumItems.text = "Items bought: " + numItemsBoughtOne.ToString();
        playerTwoNumItems.text = "Items bought: " + numItemsBoughtTwo.ToString();

        if (scoreOne > scoreTwo)
        {
            playerWinner.text = "Player 1 won!";
        }
        else if (scoreTwo > scoreOne)
        {
            playerWinner.text = "Player 2 won!";
        }
        else
        {
            playerWinner.text = "It's a tie!";
        }
    }

    private void OnDestroy()
    {
        EventSystemGame.current.onGameOver -= ShowTimeIsUp;
        EventSystemGame.current.onStatsSent -= StoreStats;
    }

}
