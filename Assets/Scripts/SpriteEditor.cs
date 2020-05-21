using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteEditor : MonoBehaviour
{
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
