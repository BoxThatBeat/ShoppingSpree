using UnityEngine;

public enum direction
{
    northward,eastward,southward,westward
}

public class CarController : MonoBehaviour
{

    public CarSettings settings;
    public direction dir;

    public Sprite north;
    public Sprite east;
    public Sprite south;
    public Sprite west;

    public bool accelerating { private get; set; }

    private Vector3 movement;
    private Rigidbody2D rb;
    public float currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        accelerating = true;
        currentVelocity = settings.startVelocity;
    }


    public void SetSprite() //set the corect sprite
    {
        switch (dir)
        {
            case direction.northward:
                GetComponent<SpriteRenderer>().sprite = north;
                break;

            case direction.eastward:
                GetComponent<SpriteRenderer>().sprite = east;
                break;

            case direction.southward:
                GetComponent<SpriteRenderer>().sprite = south;
                break;

            case direction.westward:
                GetComponent<SpriteRenderer>().sprite = west;
                break;
        }
    }

    private void FixedUpdate() //Movement
    {
        switch (dir)
        {
            case direction.northward:
                if (accelerating)
                    Accelerate(0f, 1f);
                else
                    Deccelerate(0f, 1f);
                break;

            case direction.eastward:
                if (accelerating)
                    Accelerate(1f, 0f);
                else
                    Deccelerate(1f, 0f);
                break;

            case direction.southward:
                if (accelerating)
                    Accelerate(0f, 1f);
                else
                    Deccelerate(0f, 1f);
                break;

            case direction.westward:
                if (accelerating)
                    Accelerate(1f, 0f);
                else
                    Deccelerate(1f, 0f);
                break;
        }
    }

    private void Deccelerate(float xDir, float yDir)
    {
        if (currentVelocity > settings.deccel)
            currentVelocity -= settings.deccel;

        Vector3 vector = new Vector3(xDir, yDir, 0f);
        rb.MovePosition(transform.position + vector * currentVelocity * Time.fixedDeltaTime);
    }

    private void Accelerate(float xDir, float yDir)
    {


        if (currentVelocity < settings.maxVelocity)
            currentVelocity += settings.accel;

        Vector3 vector = new Vector3(xDir, yDir, 0f);
        rb.MovePosition(transform.position + vector * currentVelocity * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().GoToHospital();
        }
    }
}
