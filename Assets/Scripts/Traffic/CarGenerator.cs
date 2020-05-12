using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    /*
    public List<GameObject> Cars;

    public Transform restartpos;
    public string direction;

    private List<Transform> CarInstances = new List<Transform>();
    private int timer;
    private int carsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 600);
    }

    public enum Direction
    {
        westward,eastward,nothward,southward
    }

    // Update is called once per frame
    void Update()
    {
        if (carsSpawned < 5 && timer == 0)
        {
            if (direction == "north")
            {
                var instance = Instantiate(CarsN[Random.Range(0, CarsN.Count)], gameObject.transform.position, Quaternion.identity) as Transform;
                CarInstances.Add(instance);
            }
            else if (direction == "east")
            {
                var instance = Instantiate(CarsE[Random.Range(0, CarsE.Count)], gameObject.transform.position, Quaternion.identity) as Transform;
                CarInstances.Add(instance);
            }
            else if (direction == "south")
            {
                var instance = Instantiate(CarsS[Random.Range(0, CarsS.Count)], gameObject.transform.position, Quaternion.identity) as Transform;
                CarInstances.Add(instance);
            }
            else if (direction == "west")
            {
                var instance = Instantiate(CarsW[Random.Range(0, CarsW.Count)], gameObject.transform.position, Quaternion.identity) as Transform;
                CarInstances.Add(instance);
            }

            carsSpawned += 1;
            timer = Random.Range(0, 600);
        }
        else
        {
            timer -= 1;
        }

        if (direction == "east")
        {
            if (CarInstances.Count > 0)
            {
                foreach (var car in CarInstances)
                {
                    if (car.position.x >= restartpos.position.x)
                    {
                        car.position = gameObject.transform.position;
                    }
                }
            }
        }
        else if (direction == "west")
        {
            if (CarInstances.Count > 0)
            {
                foreach (var car in CarInstances)
                {
                    if (car.position.x <= restartpos.position.x)
                    {
                        car.position = gameObject.transform.position;
                    }
                }
            }
        }
        else if (direction == "south")
        {
            if (CarInstances.Count > 0)
            {
                foreach (var car in CarInstances)
                {
                    if (car.position.y <= restartpos.position.y)
                    {
                        car.position = gameObject.transform.position;
                    }
                }
            }
        }
        else if (direction == "north")
        {
            if (CarInstances.Count > 0)
            {
                foreach (var car in CarInstances)
                {
                    if (car.position.y >= restartpos.position.y)
                    {
                        car.position = gameObject.transform.position;
                    }
                }
            }
        }

    }
    */
}
