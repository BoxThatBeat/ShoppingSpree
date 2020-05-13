using UnityEngine;

public enum characters
{
    aaron,pdanny,jen
}

public class PlayerSpawner : MonoBehaviour
{
    public Settings gameSettings;
    public CameraController camOne;
    public CameraController camTwo;

    public Transform playerOneSpawnPos;
    public Transform playerTwoSpawnPos;

    public characters playerOneChoice;
    public characters playerTwoChoice;

    [SerializeField] private GameObject characterAaron = null;
    [SerializeField] private GameObject characterPdanny = null;
    [SerializeField] private GameObject characterJen = null;

    private GameObject PlayerOne;
    private GameObject PlayerTwo;

    private string controlType;

    public void Start()
    {
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        if (gameSettings.usingControllers)//setup input type
            controlType = "J";
        else
            controlType = "K";

        //Spawn player one
        switch (playerOneChoice)
        {
            case characters.aaron:
                PlayerOne = Instantiate(characterAaron, playerOneSpawnPos);
                PlayerOne.GetComponent<PlayerInput>().SetupInput(controlType, 1);
                break;

            case characters.pdanny:
                PlayerOne = Instantiate(characterPdanny, playerOneSpawnPos);
                PlayerOne.GetComponent<PlayerInput>().SetupInput(controlType, 1);
                break;

            case characters.jen:
                PlayerOne = Instantiate(characterJen, playerOneSpawnPos);
                PlayerOne.GetComponent<PlayerInput>().SetupInput(controlType, 1);
                break;

        }

        //Spawn player two
        switch (playerTwoChoice)
        {
            case characters.aaron:
                PlayerTwo = Instantiate(characterAaron, playerTwoSpawnPos);
                PlayerTwo.GetComponent<PlayerInput>().SetupInput(controlType, 2);
                break;

            case characters.pdanny:
                PlayerTwo = Instantiate(characterPdanny, playerTwoSpawnPos);
                PlayerTwo.GetComponent<PlayerInput>().SetupInput(controlType, 2);
                break;

            case characters.jen:
                PlayerTwo = Instantiate(characterJen, playerTwoSpawnPos);
                PlayerTwo.GetComponent<PlayerInput>().SetupInput(controlType, 2);
                break;

        }

        camOne.lockTarget(PlayerOne.transform);
        camTwo.lockTarget(PlayerTwo.transform);
    }

}
