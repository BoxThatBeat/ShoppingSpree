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
        LetCarsGo();
    }

    private void LetCarsGo()
    {
        if (carsStopped.Count > 0)
        {
            //reset the colider box
            switch (dir)
            {
                case direction.northward:
                    transform.position = new Vector2(transform.position.x, transform.position.y + carsStopped.Count * settings.ColliderMoveDistance);
                    break;
                case direction.eastward:
                    transform.position = new Vector2(transform.position.x + carsStopped.Count * settings.ColliderMoveDistance, transform.position.y);
                    break;
                case direction.southward:
                    transform.position = new Vector2(transform.position.x, transform.position.y - carsStopped.Count * settings.ColliderMoveDistance);
                    break;
                case direction.westward:
                    transform.position = new Vector2(transform.position.x - carsStopped.Count * settings.ColliderMoveDistance, transform.position.y);
                    break;
            }

            int numCars = carsStopped.Count;
            for (int i = 0; i < numCars; i++)
            {
                StartCoroutine(LetCarGo(carsStopped.Dequeue(), i + 1)); //start coroutines to let all cars go one at a time with intervals: 0.5, 1 , 1.5 seconds
            }
            
        }
        
    }

    private IEnumerator LetCarGo(CarController car, float time)
    {
        yield return new WaitForSeconds(time/2);
        car.accelerating = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            car = collision.GetComponent<CarController>();

            if (currentState == lightColor.red && car.direction == dir)
            {
                car.accelerating = false; //Tell car to slow down
                carsStopped.Enqueue(car); //Add car to list of stopped cars to allow them to go when it turns green

                //move colider back in the correct direction by the amount set in the settings 
                switch (dir)
                {
                    case direction.northward:
                        transform.position = new Vector2(transform.position.x, transform.position.y - settings.ColliderMoveDistance);
                        break;
                    case direction.eastward:
                        transform.position = new Vector2(transform.position.x - settings.ColliderMoveDistance, transform.position.y);
                        break;
                    case direction.southward:
                        transform.position = new Vector2(transform.position.x, transform.position.y + settings.ColliderMoveDistance);
                        break;
                    case direction.westward:
                        transform.position = new Vector2(transform.position.x + settings.ColliderMoveDistance, transform.position.y);
                        break;
                }

            }  
        }
    }


    
}
