using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController player;
    private PlayerInteracter playerInter;
    private string horizontalAxis;
    private string verticalAxis;
    private string useButton;
    private string runButton;
    private string dropButton;

    private string horizontalAxisJ;
    private string verticalAxisJ;
    private string useButtonJ;
    private string runButtonJ;
    private string dropButtonJ;

    private float hAxis;
    private float vAxis;

    private float hAxisC;
    private float vAxisC;


    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<PlayerController>();
        playerInter = GetComponent<PlayerInteracter>();
    }


    public void SetupInput(int id)
    {
        GetComponent<PlayerController>().playerId = id; // set the player id on the controller

        horizontalAxis = "KHorizontal" + id;
        verticalAxis = "KVertical" + id;
        runButton = "KRun" + id;
        useButton = "KUse" + id;
        dropButton = "KDrop" + id;

        horizontalAxisJ = "JHorizontal" + id;
        verticalAxisJ = "JVertical" + id;
        runButtonJ = "JRun" + id;
        useButtonJ = "JUse" + id;
        dropButtonJ = "JDrop" + id;
    }


    private void Update()
    {

        if (Input.GetButtonDown(useButton) || Input.GetButtonDown(useButtonJ))
            playerInter.OnUse();
        if (Input.GetButtonDown(dropButton) || Input.GetButtonDown(dropButtonJ))
            playerInter.DropItem();

        if (Input.GetButtonDown(runButton) || Input.GetButtonDown(runButtonJ))
            player.OnRunning();
        else if (Input.GetButtonUp(runButton) || Input.GetButtonUp(runButtonJ))
            player.OnWalking();

        //always send axis info
        hAxis = Input.GetAxis(horizontalAxis);
        vAxis = Input.GetAxis(verticalAxis);

        hAxisC = Input.GetAxis(horizontalAxisJ);
        vAxisC = Input.GetAxis(verticalAxisJ);

        if (hAxisC != 0f || vAxisC != 0f)
        {
            player.OnMove(hAxisC, vAxisC);
        }
        else
        {
            player.OnMove(hAxis, vAxis);
        }

        



    }
}
