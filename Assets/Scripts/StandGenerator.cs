using UnityEngine;

public class StandGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] spawns;
    [SerializeField] private GameObject[] foodStands;
    [SerializeField] private GameObject atm;


    void Start()
    {
        foreach (Transform spawn in spawns)
        {
            int randChoice = Random.Range(0, 2);

            if (randChoice == 0)
                Instantiate(foodStands[Random.Range(0, foodStands.Length)], spawn.position, transform.rotation);
            else
                Instantiate(atm, spawn.position, transform.rotation);
        }
    }

}
