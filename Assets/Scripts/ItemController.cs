using UnityEngine;

public class ItemController : MonoBehaviour, IInteractable
{

    public int price;
    public Sprite sprite;

    [SerializeField] private Item itemInfo = null;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sprite = itemInfo.sprite;
    }

    private void Start()
    {
        sr.sprite = sprite; //set the object sprite to the assigned scriptable objects sprite (dynamically set in store generation)
        price = itemInfo.price;
    }

    public void Interact(GameObject player)
    {
        player.GetComponent<PlayerInteracter>().SetItem(itemInfo); //give the player the item info
        Destroy(this.gameObject);//delete the item picked up, the player must sell the item and cannot leave the shop until they do
    }
}
