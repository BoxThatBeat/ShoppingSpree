using System.Collections;
using UnityEngine;

public class TailGateTrigger : MonoBehaviour
{
    public TrafficSettings settings;
    private CarController carBehind;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
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
    }
}
