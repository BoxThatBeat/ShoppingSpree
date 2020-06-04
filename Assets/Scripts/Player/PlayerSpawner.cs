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

    private characters playerOneChoice;
    private characters playerTwoChoice;

    [SerializeField] private GameObject characterAaron = null;
    [SerializeField] private GameObject characterPdanny = null;
    [SerializeField] private GameObject characterJen = null;

    private GameObject player;

    public void Start()
    {
        playerOneChoice = GameManager.Instance.playerOneCharacter;
        playerTwoChoice = GameManager.Instance.playerTwoCharacter;
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        //Spawn player one
        switch (playerOneChoice)
        {
            case characters.aaron:
                CreatePlayer(characterAaron, playerOneSpawnPos, camOne, 1);
                break;

            case characters.pdanny:
                CreatePlayer(characterPdanny, playerOneSpawnPos, camOne, 1);
                break;

            case characters.jen:
                CreatePlayer(characterJen, playerOneSpawnPos, camOne, 1);
                break;
        }

        //Spawn player two
        switch (playerTwoChoice)
        {
            case characters.aaron:
                CreatePlayer(characterAaron, playerTwoSpawnPos, camTwo, 2);
                break;

            case characters.pdanny:
                CreatePlayer(characterPdanny, playerTwoSpawnPos, camTwo, 2);
                break;

            case characters.jen:
                CreatePlayer(characterJen, playerTwoSpawnPos, camTwo, 2);
                break;

        }
    }

    private void CreatePlayer(GameObject character, Transform spawn, CameraController camera, int id)
    {
        player = Instantiate(character, spawn);
        player.GetComponent<PlayerInput>().SetupInput(id);

        camera.lockTarget(player.transform);
    }

}
