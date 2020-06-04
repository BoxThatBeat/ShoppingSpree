using System.Collections;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    public TextMeshProUGUI scoreLoss;
    public int player;
    public float startPosX;

    public LeanTweenType easeTypeScore;

    private int difference;
    private bool scoreAnimReady = true;

    private void OnEnable()
    {
        EventSystemUI.current.onScoreChanged += ChangeScore;
    }
    private void OnDisable()
    {
        EventSystemUI.current.onScoreChanged -= ChangeScore;
    }

    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        scoreLoss.enabled = false;
    }

    private void ChangeScore(int playerId, int amount)
    {

        if (player == playerId)
        {
            difference = amount - int.Parse(score.text.Substring(1));

            if (difference > 0 && scoreAnimReady)//if there is a positive difference between the old score and the new then show in the negative UI
            {
                scoreAnimReady = false;
                scoreLoss.text = "+$" + difference.ToString();
                scoreLoss.enabled = true;
                LeanTween.moveLocalX(scoreLoss.gameObject, 10f, 0.5f).setEase(easeTypeScore).setOnComplete(ResetGUI);
            }

            score.text = "$" + amount.ToString(); //update the money UI with the new amount
        }
    }

    private void ResetGUI()
    {
        StartCoroutine(ResetScore());
    }

    private IEnumerator ResetScore()
    {
        yield return new WaitForSeconds(0.5f);

        LeanTween.moveX(scoreLoss.GetComponent<RectTransform>(), startPosX, 0.2f);

        yield return new WaitForSeconds(0.2f);
        scoreLoss.enabled = false;
        scoreAnimReady = true;
    }
}

