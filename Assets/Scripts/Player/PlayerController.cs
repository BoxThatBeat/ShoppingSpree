using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public PlayerSettings settings;
    public GameObject HospitalSpawn;

    [Space]
    [Header("Player Stats:")]
    public int playerId = 0;
    public Vector2 currentMovement;
    public bool stopped;

    public int money;
    public int score;

    private Rigidbody2D rb;
    private bool running;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        money = settings.startMoney;
        EventSystemUI.current.ChangeMoneyUI(playerId, money);

    }

    #region Money and Score
    public void AddMoney(int amount)
    {
        money += amount;
        EventSystemUI.current.ChangeMoneyUI(playerId, money);
    }
    public void AddScore(int amount)
    {
        score += amount;
        EventSystemUI.current.ChangeScoreUI(playerId, score);
    }
    public void SubtractMoney(int amount)
    {
        money -= amount;
        EventSystemUI.current.ChangeMoneyUI(playerId, money);
    }
    public void SubtractScore(int amount)
    {
        score -= amount;
        EventSystemUI.current.ChangeScoreUI(playerId, score);
    }
    #endregion

    #region Movement
    public void OnMove(float HAxis, float VAxis)
    {
        if (!stopped)
        {
            currentMovement = new Vector2(HAxis, VAxis);
        }
        else
        {
            currentMovement.x = 0f; //block movement
            currentMovement.y = 0f; //block movement
        }
    }

    public void OnRunning()
    {
        running = true;
    }

    public void OnWalking()
    {
        running = false;
    }

   private void FixedUpdate()
    {

        if (running)
        {

            rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * settings.runSpeed * Time.fixedDeltaTime
                                    , transform.position.y + currentMovement.y * settings.runSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * settings.walkSpeed * Time.fixedDeltaTime
                                    , transform.position.y + currentMovement.y * settings.walkSpeed * Time.fixedDeltaTime));
        }    
    }

    public void StartBlockMovement(float time) //used to access this coroutine outside of the class
    {
        StartCoroutine(BlockMovement(time));
    }

    private IEnumerator BlockMovement(float time)
    {
        stopped = true;
        yield return new WaitForSeconds(time);
        stopped = false;
    }

    #endregion

    #region Transportation
    public void GoToHospital()
    {
        EventSystemGame.current.FadePlayer(playerId, settings.knockOutFadeTime);
        transform.position = HospitalSpawn.transform.position;

        money -= 500;
        EventSystemUI.current.ChangeMoneyUI(playerId, money);

        StartBlockMovement(settings.blockTimeToHospital);
        //should also play a flashing white animation in the future
    }

    public void GoToStore(Vector2 storePos)
    {
        EventSystemGame.current.FadePlayer(playerId, settings.knockOutFadeTime);
        transform.position = storePos;
        GetComponent<SpriteRenderer>().sortingLayerName = "StoreDefault";
        StartBlockMovement(settings.StoreFadeTime);
    }

    public void ExitStore(Vector2 doorPos)
    {
        EventSystemGame.current.FadePlayer(playerId, settings.knockOutFadeTime);
        transform.position = doorPos;
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        StartBlockMovement(settings.StoreFadeTime);
    }
    #endregion

}
