using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    [Header("Settings and Attribute scriptable objects:")]
    public CharacterAttributes attributes;
    public PlayerSettings settings;
    [SerializeField] private GameObject HospitalSpawn = null;

    //these are attributes not to be set in the inspector
    [NonSerialized] public int playerId = 0;
    [NonSerialized] public Vector2 currentMovement;
    [NonSerialized] public bool stopped;

    public int money { get; private set; }
    public int score { get; private set; }
    public float stamina { get; private set; }
    [NonSerialized] public float maxStamina;
    [NonSerialized] public int moneyInBank = 0;
    [NonSerialized] public int numItemsBought = 0;
    [NonSerialized] public int moneySpent = 0;

    private Rigidbody2D rb;
    private bool running;

    private void Awake()
    {
        money = 0;
        score = 0;
        stamina = 0;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EventSystemGame.current.onGameOver += OnGameOver;

        maxStamina = attributes.maxStamina;
        AddStamina(maxStamina);
        EventSystemUI.current.SetMaxStamina(playerId,maxStamina);

        AddMoney(attributes.pocketSize);
        moneyInBank = attributes.maxMoneyInBank;

        StartBlockMovement(3f); //block movement for the first 3 seconds for the camera zoom in;
    }

    private void OnGameOver()
    {
        stopped = true;

        EventSystemGame.current.SendStats(playerId, score, numItemsBought);
    }

    #region Money and Score and Stamina

    public void AddStamina(float amount)
    {
        if (stamina + amount >= maxStamina) //case where adding too much stamina
            stamina = maxStamina;
        else
            stamina += amount;

        EventSystemUI.current.ChangeStaminaUI(playerId, stamina);
    }
    public void AddMoney(int amount)
    {
        EventSystemUI.current.ChangeMoneyUI(playerId, money += amount);
    }
    public void AddScore(int amount)
    {
        EventSystemUI.current.ChangeScoreUI(playerId, score += amount);
    }
    public void SubtractStamina(float amount)
    {
        if (stamina - amount <= 0) //case where adding too much stamina
            stamina = 0;
        else
            stamina -= amount;

        EventSystemUI.current.ChangeStaminaUI(playerId, stamina);
    }
    public void SubtractMoney(int amount)
    {
        if (money - amount <= 0) //case where adding too much stamina
            money = 0;
        else
            money -= amount;

        EventSystemUI.current.ChangeMoneyUI(playerId, money);
    }
    /*
    public void SubtractScore(int amount)
    {
        EventSystemUI.current.ChangeScoreUI(playerId, score -= amount);
    }
    */
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

    public void OnRunning() //only called once when running button is pressed down
    {
        running = true;
        EventSystemGame.current.PlayerRunning(playerId, true);
        EventSystemGame.current.PlaySound("Run");
    }

    public void OnWalking()//only called once when running button is unpressed
    {
        running = false;
        EventSystemGame.current.PlayerRunning(playerId, false);
        EventSystemGame.current.StopSound("Run");
    }

   private void FixedUpdate()
    {

        if (running && stamina != 0)
        {
            if (currentMovement.x != 0 || currentMovement.y != 0) //make sure the player is actually moving and not just holding the sprint button
                SubtractStamina(settings.staminaDecreaseInterval);//use stamina while running

            rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * attributes.runSpeed * Time.fixedDeltaTime
                                    , transform.position.y + currentMovement.y * attributes.runSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * attributes.walkSpeed * Time.fixedDeltaTime
                                    , transform.position.y + currentMovement.y * attributes.walkSpeed * Time.fixedDeltaTime));
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
        EventSystemGame.current.FadePlayer(playerId, attributes.knockOutFadeSpeed);
        transform.position = HospitalSpawn.transform.position;

        SubtractMoney(settings.hospitalCost);

        StartBlockMovement(attributes.knockOutFadeSpeed);
        //should also play a flashing white animation in the future
    }

    public void GoToStore(Vector2 storePos) //could make GoToStore and ExitStore into one function
    {
        EventSystemGame.current.FadePlayer(playerId, settings.storeFadeTime);
        transform.position = storePos;
        GetComponent<SpriteRenderer>().sortingLayerName = "StoreDefault";
        StartBlockMovement(settings.blockTimeToStore);
    }

    public void ExitStore(Vector2 doorPos)
    {
        EventSystemGame.current.FadePlayer(playerId, settings.storeFadeTime);
        transform.position = doorPos;
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        StartBlockMovement(settings.blockTimeToStore);
    }
    #endregion

}
