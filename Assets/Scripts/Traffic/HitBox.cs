﻿using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Collider2D colBoxX;
    public Collider2D colBoxY;

    public void SetCollider(direction d)
    {

        if (d == direction.eastward || d == direction.westward)
        {
            colBoxX.enabled = true;
            colBoxY.enabled = false;
        }
        else if (d == direction.northward || d == direction.southward)
        {
            colBoxX.enabled = false;
            colBoxY.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().GoToHospital();
        }
    }
}
