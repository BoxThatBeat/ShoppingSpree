using System.Collections;
using UnityEngine;

public class TailGateTrigger : MonoBehaviour
{
    public TrafficSettings settings;
    private CarController carBehind = null;
    private CarController myCar = null;

    public Collider2D colNorthward = null;
    public Collider2D colEastward = null;
    public Collider2D colSouthward = null;
    public Collider2D colWestward = null;

    private void Start()
    {
        myCar = GetComponentInParent<CarController>();
    }

    public void SetCollider(direction d)
    {

        //deactive all colliders before activating one
        colNorthward.enabled = false;
        colEastward.enabled = false;
        colSouthward.enabled = false;
        colWestward.enabled = false;

        switch (d)
        {
            case direction.northward:
                colNorthward.enabled = true;
                break;

            case direction.eastward:
                colEastward.enabled = true;
                break;

            case direction.southward:
                colSouthward.enabled = true;
                break;

            case direction.westward:
                colWestward.enabled = true;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("slowdown");
        if (collision.gameObject.tag == "Car" && carBehind == null && myCar.accelerating == false)
        {
            carBehind = collision.GetComponent<CarController>();

            carBehind.accelerating = false; //Tell car to slow down
            StartCoroutine(LetCarGo(carBehind));
        }
    }

    private IEnumerator LetCarGo(CarController car)
    {
        yield return new WaitForSeconds(settings.letGoTime);
        car.accelerating = true;
        carBehind = null;
    }
}
