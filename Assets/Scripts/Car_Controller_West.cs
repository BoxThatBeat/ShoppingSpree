using UnityEngine;

public class Car_Controller_West : MonoBehaviour
{
    public float H_SPEED = -0.15f;
    public GameObject playerOne;
    public GameObject HospitalSpawn;

    private void Start()
    {
        //Get player1 ref from the gamemanager that instantiated the player
        playerOne = GameManager.Instance.playerOne;

    }

    void Update() //Movement
    {
        Vector3 movement = new Vector3(H_SPEED, 0.0f, 0.0f);
        transform.position = transform.position + movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other == playerOne.GetComponent("Collider2D")) //Car hit player
        {
            GameManager.Instance.StartCoroutine("Blackout");

            playerOne.transform.position = HospitalSpawn.transform.position;

            if (GameManager.Instance.getMoney() >= 100)
            {
                GameManager.Instance.setMoney(-100.0f);
            }
            else
            {
                GameManager.Instance.setMoney(0.0f);
            }

        }
    }

}
