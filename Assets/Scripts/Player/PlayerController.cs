using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    [Space]
    [Header("Settings and Attribute scriptable objects:")]
    public CharacterAttributes attributes;
    public PlayerSettings settings;
    public GameObject HospitalSpawn;

    //these are attributes not to be set in the inspector
    [NonSerialized] public int playerId = 0;
    [NonSerialized] public Vector2 currentMovement;
    [NonSerialized] public bool stopped;

    [NonSerialized] public int money;
    [NonSerialized] public int score;
    [NonSerialized] public float maxStamina;
    [NonSerialized] public float stamina;
    

    private Rigidbody2D rb;
    private bool running;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        maxStamina = attributes.maxStamina;
        stamina = maxStamina;
        EventSystemUI.current.SetMaxStamina(playerId, attributes.maxStamina);

        money = attributes.startMoney;
        EventSystemUI.current.ChangeMoneyUI(playerId, money);

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
        EventSystemUI.current.ChangeMoneyUI(playerId, money -= amount);
    }
    public void SubtractScore(int amount)
    {
        EventSystemUI.current.ChangeScoreUI(playerId, score -= amount);
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

        if (running && stamina != 0)
        {
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
        EventSystemGame.current.FadePlayer(playerId, attributes.knockOutFadeTime);
        transform.position = HospitalSpawn.transform.position;

        money -= 500;
        EventSystemUI.current.ChangeMoneyUI(playerId, money);

        StartBlockMovement(settings.blockTimeToHospital);
        //should also play a flashing white animation in the future
    }

    public void GoToStore(Vector2 storePos)
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
