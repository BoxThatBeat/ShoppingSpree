using UnityEngine;

public class Player1_Controller : MonoBehaviour{

    private const float MOVEMENT_BASE_SPEED = 4.5f;

    [Space]
    [Header("References:")]
    public Animator animator;
    public Rigidbody2D rb;
    public float InputX;
    public float InputY;

    [Space]
    [Header("Player Stats:")]
    public int playerId = 0;
    public float movementSpeed;


    private void Awake()
    {
        //makes the player script not be destroyed on loading a level
        DontDestroyOnLoad(transform.gameObject);
    }


    // Update is called once per frame
    void FixedUpdate(){

        
        if (!GameManager.Instance.StopPlayer)
        {

            InputX = Input.GetAxisRaw("Horizontal_1");
            InputY = Input.GetAxisRaw("Vertical_1");

            Vector3 movement = new Vector3(InputX, InputY, 0); //creates new vector object
            

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            //transform.Translate(movement * Time.deltaTime);
            rb.MovePosition(new Vector2(transform.position.x + movement.x * MOVEMENT_BASE_SPEED * Time.deltaTime , transform.position.y + movement.y * MOVEMENT_BASE_SPEED * Time.deltaTime));
        }
        else
        {
            animator.SetFloat("Horizontal", 0.0f);
            animator.SetFloat("Vertical", 0.0f);
            animator.SetFloat("Magnitude", 0.0f);
        }

        /*
        // Updates the user's money (note: if we have methods for adding/subtracting money, it would be ideal to place this in each of those)
        moneyText.text = "$" + money.ToString();

        gameTimer += Time.deltaTime;

        int minutes = (int)(gameTimer % 60 );// (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 60);

        string timerString = string.Format("{0:00}:{1:00}", hours, minutes);

        timeText.text = timerString;
        */

    }
}
