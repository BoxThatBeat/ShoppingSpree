using UnityEngine;

public enum direction
{
    northward,eastward,southward,westward
}

public class Car_Controller : MonoBehaviour
{
    [SerializeField]private float speed = 0.15f;

    public GameObject playerOne;
    public GameObject HospitalSpawn;
    public direction dir;

    private Vector3 movement;

    void Update() //Movement
    {
        switch (dir)
        {
            case direction.northward:
                movement = new Vector3(0f, speed, 0f);
                transform.position = transform.position + movement;
                break;
            case direction.eastward:
                movement = new Vector3(speed, 0f, 0f);
                transform.position = transform.position + movement;
                break;
            case direction.southward:
                movement = new Vector3(0f, -speed, 0f);
                transform.position = transform.position + movement;
                break;
            case direction.westward:
                movement = new Vector3(-speed, 0f, 0f);
                transform.position = transform.position + movement;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other == playerOne.GetComponent("Collider2D")) //Car hit player
        {

            playerOne.transform.position = HospitalSpawn.transform.position;

            
        }
        */
    }

}
