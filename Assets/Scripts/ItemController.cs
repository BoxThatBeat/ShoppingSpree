using UnityEngine;

public class ItemController : MonoBehaviour
{

    public int price;
    public Sprite sprite;

    [SerializeField] private Item itemInfo;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sprite = itemInfo.sprite;
    }

    void Start()
    {
        sr.sprite = sprite; //set the object sprite to the assigned scriptable objects sprite (dynamically set in store generation)
        price = itemInfo.price;
    }
}
