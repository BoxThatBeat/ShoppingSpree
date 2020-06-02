using System;
using UnityEngine;

public class ExitStore : MonoBehaviour
{
    [NonSerialized] public Transform door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInteracter>().heldItem)
            {
                collision.GetComponent<PlayerInteracter>().DropItem();
            }

            collision.GetComponent<PlayerController>().ExitStore(new Vector2(door.position.x, door.position.y - 0.5f));
        }
    }
}
