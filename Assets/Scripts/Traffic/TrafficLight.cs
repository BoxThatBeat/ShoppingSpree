using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public enum lightColor
{
    green,yellow,red
}

public class TrafficLight : MonoBehaviour
{
    
    public direction dir;
    public TrafficSettings settings;
    public Light2D trafficLight;

    private Queue<CarController> carsStopped;
    private CarController car = null;
    private bool readyToMove = true;

    public lightColor currentState;

    private void SetCurrentState(lightColor state)
    {
        currentState = state;

        switch (currentState)
        {
            case lightColor.green:
                trafficLight.color = Color.green;
                break;
            case lightColor.yellow:
                trafficLight.color = Color.yellow;
                break;
            case lightColor.red:
                trafficLight.color = Color.red;
                break;
        }
    }

    private void Awake()
    {
        SetCurrentState(lightColor.green);
    }

    private void Start()
    {
        carsStopped = new Queue<CarController>(); //init queue of cars
    }

    private void Update()
    {
        if (carsStopped.Count != 0 && currentState == lightColor.green && readyToMove)
        {
            StartCoroutine(LetCarGo(carsStopped.Dequeue()));
        }
    }

    public void SwitchLight()
    {
        if (currentState == lightColor.green)
        {
            StartCoroutine(ChangeToRed());
        }
        else if (currentState == lightColor.red)
        {
            StartCoroutine(ChangeToGreen());
        }
    }

    private IEnumerator ChangeToRed()
    {
        SetCurrentState(lightColor.yellow);
        yield return new WaitForSeconds(settings.yellowTime);
        SetCurrentState(lightColor.red);

    }
    private IEnumerator ChangeToGreen()
    {
        yield return new WaitForSeconds(settings.yellowTime);
        SetCurrentState(lightColor.green);
    }

    private IEnumerator LetCarGo(CarController car)
    {
        car.accelerating = true;
        readyToMove = false;
        yield return new WaitForSeconds(settings.letGoTime);
        readyToMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            car = collision.GetComponent<CarController>();

            if (currentState == lightColor.red && car.direction == dir)
            {
                car.accelerating = false; //Tell car to slow down
                carsStopped.Enqueue(car); //Add car to list of stopped cars
            }  
        }
    }


    
}
