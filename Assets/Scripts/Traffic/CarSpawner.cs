using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public ObjectPool pool;
    public Transform[] eastwardSpawns;
    public Transform[] southwardSpawns;
    public Transform[] westwardSpawns;
    public Transform[] northwardSpawns;

    public CarSpawnerSettings settings;

    private bool readyToSpawn = true;
    private string color;
    private Transform location;
    private GameObject carSpawned;


    private void Update()
    {
        if (readyToSpawn)
            StartCoroutine(SpawnCar());
    }

    //spawn cars at random start locations at random intervals with a random color
    private IEnumerator SpawnCar()
    {
        readyToSpawn = false;

        switch (Random.Range(0, 4)) //choose color of car to spawn
        {
            case 0:
                color = "BlueCars";
                break;
            case 1:
                color = "GreenCars";
                break;
            case 2:
                color = "PinkCars";
                break;
            case 3:
                color = "RedCars";
                break;
        }


        //spawn car in random direction at a random coresponding spawn point
        switch (Random.Range(0, 4)) //choose color of car to spawn
        {
            case 0://northward
                location = northwardSpawns[Random.Range(0, northwardSpawns.Length - 1)];
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x,location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().dir = direction.northward;
                carSpawned.GetComponent<CarController>().SetSprite();
                break;

            case 1://easthward
                location = eastwardSpawns[Random.Range(0, eastwardSpawns.Length - 1)];
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x, location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().dir = direction.eastward;
                carSpawned.GetComponent<CarController>().SetSprite();
                break;
            case 2://southhward
                location = southwardSpawns[Random.Range(0, southwardSpawns.Length - 1)];
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x, location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().dir = direction.southward;
                carSpawned.GetComponent<CarController>().SetSprite();
                break;
            case 3://westhward
                location = westwardSpawns[Random.Range(0, westwardSpawns.Length - 1)];
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x, location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().dir = direction.westward;
                carSpawned.GetComponent<CarController>().SetSprite();
                break;
        }

        //wait before spawning another car
        yield return new WaitForSeconds(Random.Range(settings.minTimeToSpawn, settings.maxTimeToSpawn));
        readyToSpawn = true;
    }
    
}

