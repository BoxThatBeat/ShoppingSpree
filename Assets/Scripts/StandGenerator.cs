using UnityEngine;

public class StandGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] foodStands = null;
    [SerializeField] private GameObject atm = null;

    private Transform[] spawns;

    void Start()
    {
        spawns = GetComponentsInChildren<Transform>();

        for (int i = 0; i < spawns.Length; i++)
        {
            if (i != 0) //skip the first transform since it will be the parent object's
            {
                int randChoice = Random.Range(0, 2);

                if (randChoice == 0)
                    Instantiate(foodStands[Random.Range(0, foodStands.Length)], spawns[i].position, transform.rotation);
                else
                    Instantiate(atm, spawns[i].position, transform.rotation);
            }
            
        }
    }

}
