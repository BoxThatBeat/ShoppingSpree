using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int storeId;

    public DoorSettings settings;

    public Sprite doorOpen;
    public Sprite doorClosed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().StartBlockMovement(0.5f);
            GetComponent<SpriteRenderer>().sprite = doorOpen;
            StartCoroutine(LoadStore(other));
        }
    }
    
    IEnumerator LoadStore(Collision2D other)
    {
        yield return new WaitForSeconds(settings.waitTime);//show the door openning first

        other.gameObject.GetComponent<PlayerController>().GoToStore(new Vector2(100 + storeId * 100, 0));//The store interiors are seperated by 100 units on the x axis

        GetComponent<SpriteRenderer>().sprite = doorClosed;
    }
    
}
