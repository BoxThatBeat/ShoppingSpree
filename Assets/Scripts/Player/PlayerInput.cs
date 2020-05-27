using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController player;
    private PlayerInteracter playerInter;
    private string horizontalAxis;
    private string verticalAxis;
    private string useButton;
    private string runButton;

    private float hAxis;
    private float vAxis;


    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<PlayerController>();
        playerInter = GetComponent<PlayerInteracter>();
    }


    public void SetupInput(string type, int id)
    {
        GetComponent<PlayerController>().playerId = id; // set the player id on the controller

        horizontalAxis = type + "Horizontal" + id;
        verticalAxis = type + "Vertical" + id;
        runButton = type + "Run" + id;
        useButton = type + "Use" + id;
    }


    private void Update()
    {

        if (Input.GetButtonDown(useButton))
            playerInter.OnUse();

        if (Input.GetButton(runButton))
            player.OnRunning();
        else
            player.OnWalking();

        //always send axis info
        hAxis = Input.GetAxis(horizontalAxis);
        vAxis = Input.GetAxis(verticalAxis);

        player.OnMove(hAxis, vAxis);


    }
}
