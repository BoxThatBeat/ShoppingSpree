using UnityEngine;

public enum SignTypes
{
    store,sale,decoration
}
public class SignEditor : MonoBehaviour
{


    public SignTypes signType;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
    }
}
