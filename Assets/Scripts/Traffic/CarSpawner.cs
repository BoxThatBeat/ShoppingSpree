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
    private int indexE = 0;
    private int indexS = 0;
    private int indexW = 0;
    private int indexN = 0;

    private void Start() //spawn a bunch of cars at the beginning to fill the city
    {
        //for (int i = 0; i < )
    }

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

        if (indexE >= eastwardSpawns.Length)
            indexE = 0;
        if (indexS >= southwardSpawns.Length)
            indexS = 0;
        if (indexW >= westwardSpawns.Length)
            indexW = 0;
        if (indexN >= northwardSpawns.Length)
            indexN = 0;

        //spawn car in random direction at a random coresponding spawn point
        switch (Random.Range(0, 4)) //choose color of car to spawn
        {
            case 0://northward
                location = northwardSpawns[indexN];
                ++indexN;
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x,location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().SetDirection(direction.northward);
                break;

            case 1://easthward
                location = eastwardSpawns[indexE];
                ++indexE;
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x, location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().SetDirection(direction.eastward);
                break;
            case 2://southhward
                location = southwardSpawns[indexS];
                ++indexS;
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x, location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().SetDirection(direction.southward);
                break;
            case 3://westhward
                location = westwardSpawns[indexW];
                ++indexW;
                carSpawned = pool.SpawnFromPool(color, new Vector2(location.position.x, location.position.y), Quaternion.identity);
                carSpawned.GetComponent<CarController>().SetDirection(direction.westward);
                break;
        }

        //wait before spawning another car
        yield return new WaitForSeconds(Random.Range(settings.minTimeToSpawn, settings.maxTimeToSpawn));
        readyToSpawn = true;
    }
    
}

