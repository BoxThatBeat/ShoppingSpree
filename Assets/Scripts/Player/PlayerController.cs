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
    private float vAxis;
    private float hAxis;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            currentMovement.x = 0f;//block movement
            currentMovement.y = 0f;//block movement
        }
    }

    public void OnUse()
    {
        Debug.Log("useButtonPressed");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(new Vector2(transform.position.x + currentMovement.x * settings.walkSpeed * Time.deltaTime 
                                    , transform.position.y + currentMovement.y * settings.walkSpeed * Time.deltaTime));
    }
}
