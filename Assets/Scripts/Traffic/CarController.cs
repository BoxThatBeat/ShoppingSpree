using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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

    public Light2D northBreakLight;
    public Light2D eastBreakLight;
    public Light2D southBreakLight;
    public Light2D westBreakLight;

    private Light2D currentBreakLight;

    public direction direction;
    public bool accelerating { get; private set; }

    private float currentVelocity;
    private float xAxisMovement;
    private float yAxisMovement;

    private Vector3 movement;
    private Rigidbody2D rb;

    public void SetAccelerating(bool accelerating)
    {
        this.accelerating = accelerating;

        if (accelerating)
            currentBreakLight.intensity = 1.0f;
        else
            currentBreakLight.intensity = 1.7f;

        //set the rigid body type since we want collisions with player when not accelerating
        /*
        if (value)
            rb.bodyType = RigidbodyType2D.Kinematic;
        else
            rb.bodyType = RigidbodyType2D.Dynamic;
            */
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        accelerating = true;
        currentVelocity = settings.startVelocity;
    }


    public void SetDirection(direction dir) //set the corect sprite
    {
        direction = dir;
        GetComponent<CarHitBox>().SetCollider(dir); //set correct hitbox direction

        //set the colider,sprite and float values for movement based on the direction set
        switch (dir)
        {
            case direction.northward:
                GetComponent<SpriteRenderer>().sprite = north;
                currentBreakLight = northBreakLight;
                xAxisMovement = 0f;
                yAxisMovement = 1f;
                break;

            case direction.eastward:
                GetComponent<SpriteRenderer>().sprite = east;
                currentBreakLight = eastBreakLight;
                xAxisMovement = 1f;
                yAxisMovement = 0f;
                break;

            case direction.southward:
                GetComponent<SpriteRenderer>().sprite = south;
                currentBreakLight = southBreakLight;
                xAxisMovement = 0f;
                yAxisMovement = -1f;
                break;

            case direction.westward:
                GetComponent<SpriteRenderer>().sprite = west;
                currentBreakLight = westBreakLight;
                xAxisMovement = -1f;
                yAxisMovement = 0f;
                break;
        }

        currentBreakLight.enabled = true;
    }

    private void FixedUpdate() //movement
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
