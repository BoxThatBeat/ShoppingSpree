using UnityEngine;

public enum SignTypes
{
    store,sale,decoration
}
public class SignEditor : MonoBehaviour
{
    public SignTypes signType;

    public void SetSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
