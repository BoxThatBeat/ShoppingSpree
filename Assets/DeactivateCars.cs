using UnityEngine;

public class DeactivateCars : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
