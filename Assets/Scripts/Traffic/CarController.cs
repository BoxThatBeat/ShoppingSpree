using UnityEngine;

public enum direction
{
    northward,eastward,southward,westward
}

public class CarController : MonoBehaviour
{
    public CarSettings settings;

    public Sprite north;
    public Sprite east;
    public Sprite south;
    public Sprite west;

    public direction direction;
    public bool accelerating;

    private float currentVelocity;
    private float xAxisMovement;
    private float yAxisMovement;

    private Vector3 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        accelerating = true;
        currentVelocity = settings.startVelocity;
    }


    public void SetDirection(direction dir) //set the corect sprite
    {
        direction = dir;
        GetComponentInChildren<TailGateTrigger>().SetCollider(dir); //set the direction for the child script
        GetComponentInChildren<CarHitBox>().SetCollider(dir);

        //set the colider,sprite and float values for movement based on the direction set
        switch (dir)
        {
            case direction.northward:
                GetComponent<SpriteRenderer>().sprite = north;
                xAxisMovement = 0f;
                yAxisMovement = 1f;
                break;

            case direction.eastward:
                GetComponent<SpriteRenderer>().sprite = east;
                xAxisMovement = 1f;
                yAxisMovement = 0f;
                break;

            case direction.southward:
                GetComponent<SpriteRenderer>().sprite = south;
                xAxisMovement = 0f;
                yAxisMovement = -1f;
                break;

            case direction.westward:
                GetComponent<SpriteRenderer>().sprite = west;
                xAxisMovement = -1f;
                yAxisMovement = 0f;
                break;
        }
    }

    private void FixedUpdate() //Movement
    {
        if (accelerating)
            Accelerate(xAxisMovement, yAxisMovement);
        else
            Deccelerate(xAxisMovement, yAxisMovement);
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
}
