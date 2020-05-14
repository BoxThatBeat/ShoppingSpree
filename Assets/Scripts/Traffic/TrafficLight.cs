using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum lightColor
{
    green,yellow,red
}

public class TrafficLight : MonoBehaviour
{
    public lightColor currentState { set; private get; }
    public direction dir;
    public TrafficSettings settings;

    private Queue<CarController> carsStopped;
    private CarController car = null;
    private bool readyToMove = true;

    private void Awake()
    {
        currentState = lightColor.green;
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
        currentState = lightColor.yellow;
        yield return new WaitForSeconds(settings.yellowTime);
        currentState = lightColor.red;

    }
    private IEnumerator ChangeToGreen()
    {
        yield return new WaitForSeconds(settings.yellowTime);
        currentState = lightColor.green;
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

            if (currentState == lightColor.red && car.dir == dir)
            {
                car.accelerating = false; //Tell car to slow down
                carsStopped.Enqueue(car); //Add car to list of stopped cars
            }  
        }
    }


    
}
