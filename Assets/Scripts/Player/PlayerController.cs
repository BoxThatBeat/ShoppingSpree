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

    public int money;      //current money
    public int moneySaved; //score

    private Rigidbody2D rb;
    private float vAxis;
    private float hAxis;
    private bool running;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        money = settings.startMoney;
        EventSystemUI.current.ChangeMoneyUI("Money", playerId, money);

    }

    public void OnMove(float HAxis, float VAxis)
    {
        hAxis = HAxis;
        vAxis = VAxis;
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

    public void OnUse()
    {
        Debug.Log("useButtonPressed");
    }

    public void OnRunning()
    {
        running = true;
    }

    public void OnWalking()
    {
        running = false;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running)
        {
            rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * settings.runSpeed * Time.deltaTime
                                    , transform.position.y + currentMovement.y * settings.runSpeed * Time.deltaTime));
        }
        else
        {
            rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * settings.walkSpeed * Time.deltaTime
                                    , transform.position.y + currentMovement.y * settings.walkSpeed * Time.deltaTime));
        }
            
    }   

    public void GoToHospital()
    {
        transform.position = HospitalSpawn.transform.position;
        money -= 200;
        EventSystemUI.current.ChangeMoneyUI("Money", playerId, money);
        EventSystemGame.current.FadePlayer(playerId, settings.knockOutFadeTime);

        StartCoroutine(BlockMovement()); //should also play a flashing white animation
    }

    private IEnumerator BlockMovement()
    {
        stopped = true;
        yield return new WaitForSeconds(settings.blockTime);
        stopped = false;
    }
}
