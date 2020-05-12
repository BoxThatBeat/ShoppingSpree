using UnityEngine;

public class PlayerController : MonoBehaviour{

    public PlayerSettings settings;

    [Space]
    [Header("Player Stats:")]
    public int playerId = 0;
    public Vector2 currentMovement;
    public bool stopped;
    public float money;
    public float moneySaved; //score

    private Rigidbody2D rb;
    private float InputX;
    private float InputY;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate(){

        if (!stopped)
        {

            InputX = Input.GetAxisRaw("Horizontal_1");
            InputY = Input.GetAxisRaw("Vertical_1");

            currentMovement = new Vector2(InputX, InputY); //creates new vector object
            
            rb.MovePosition(new Vector2(transform.position.x + InputX * settings.walkSpeed * Time.deltaTime , transform.position.y + InputY * settings.walkSpeed * Time.deltaTime));
        }
        else
        {
            InputX = 0f;//block movement
            InputY = 0f;

        }

    }
}
