using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController player;
    private string horizontalAxis;
    private string verticalAxis;
    private string jumpButton;
    private string attackButton;
    private int controllerNum;  //not used presently

    private bool usingControllers = false;
    private float hAxis;
    private float vAxis;


    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<PlayerController>();
    }


    public void SetupInput(string type, int id)
    {
        controllerNum = id;

        if (type == "C")
            usingControllers = true;

        horizontalAxis = type + "Horizontal" + id;
        verticalAxis = type + "Vertical" + id;
        jumpButton = type + "Jump" + id;
        attackButton = type + "Attack" + id;

    }


    private void FixedUpdate()
    {
        Debug.Log("it's here");
        if (Input.GetButton(jumpButton))
            player.OnJump();
        if (Input.GetButton(attackButton))
            player.OnAttack();
        if (Input.GetAxis(verticalAxis) < -0.1f)
            player.OnCrouch();

        //always send axis info
        hAxis = Input.GetAxis(horizontalAxis);
        vAxis = Input.GetAxis(verticalAxis);

        player.OnMove(hAxis, vAxis);


    }
}
