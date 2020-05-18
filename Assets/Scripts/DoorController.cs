using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int storeId;

    public Sprite doorOpen;
    public Sprite doorClosed;

    public float waitTime;
    public float transitionTime;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().StartBlockMovement(0.5f);
            GetComponent<SpriteRenderer>().sprite = doorOpen;
            StartCoroutine(LoadStore(other));
        }
    }
    
    IEnumerator LoadStore(Collider2D other)
    {
        yield return new WaitForSeconds(waitTime);//show the door openning first

        other.GetComponent<PlayerController>().GoToStore(new Vector2(storeId * 200, 0));//The store interiors are seperated by 200 units

        GetComponent<SpriteRenderer>().sprite = doorClosed;
    }
    
}
