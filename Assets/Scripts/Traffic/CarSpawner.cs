using System.Collections;
using UnityEngine;


//spawn cars at random start locations at random intervals with a random color
public class CarSpawner : MonoBehaviour
{
    public ObjectPool pool;
    public Transform[] eastwardSpawns;
    public Transform[] southwardSpawns;
    public Transform[] westwardSpawns;
    public Transform[] northwardSpawns;

    private int indexE = 0;
    private int indexS = 0;
    private int indexW = 0;
    private int indexN = 0;

    public Transform[] eastwardStartSpawns;
    public Transform[] southwardStartSpawns;
    public Transform[] westwardStartSpawns;
    public Transform[] northwardStartSpawns;

    public CarSpawnerSettings settings;

    private bool readyToSpawn = true;
    private string color;
    private Transform location;
    private direction dir;
    private GameObject carSpawned;
   

    private void Start() //spawn a bunch of cars at the beginning to fill the city
    {
        foreach (Transform spawn in northwardStartSpawns)
        {
            SpawnCar(spawn, direction.northward);
        }
        foreach (Transform spawn in eastwardStartSpawns)
        {
            SpawnCar(spawn, direction.eastward);
        }
        foreach (Transform spawn in southwardStartSpawns)
        {
            SpawnCar(spawn, direction.southward);
        }
        foreach (Transform spawn in westwardStartSpawns)
        {
            SpawnCar(spawn, direction.westward);
        }
    }

    private void Update()
    {
        if (readyToSpawn)
            StartCoroutine(SpawnCarWithInterval());
    }

    private IEnumerator SpawnCarWithInterval()
    {
        readyToSpawn = false;

        //spawn car in random direction at a random coresponding spawn point
        switch (Random.Range(0, 4))
        {
            case 0://northward
                location = northwardSpawns[indexN++];
                dir = direction.northward;
                if (indexN >= northwardSpawns.Length)
                    indexN = 0;
                break;

            case 1://easthward
                location = eastwardSpawns[indexE++];
                dir = direction.eastward;
                if (indexE >= eastwardSpawns.Length)
                    indexE = 0;
                break;

            case 2://southward
                location = southwardSpawns[indexS++];
                dir = direction.southward;
                if (indexS >= southwardSpawns.Length)
                    indexS = 0;
                break;

            case 3://westhward
                location = westwardSpawns[indexW++];
                dir = direction.westward;
                if (indexW >= westwardSpawns.Length)
                    indexW = 0;
                break;
        }

        SpawnCar(location,dir);

        //wait before spawning another car
        yield return new WaitForSeconds(Random.Range(settings.minTimeToSpawn, settings.maxTimeToSpawn));
        readyToSpawn = true;
    }

    private void SpawnCar(Transform spawn, direction dir)
    {
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

        carSpawned = pool.SpawnFromPool(color, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);
        carSpawned.GetComponent<CarController>().SetDirection(dir);
    }

}

