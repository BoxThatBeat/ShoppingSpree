using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{

	[SerializeField] private Collider2D colUp = null;
	[SerializeField] private Collider2D colDown = null;
	[SerializeField] private Collider2D colRight = null;
	[SerializeField] private Collider2D colLeft = null;

	private PlayerController player = null;
	
	void Start()
    {
		player = GetComponent<PlayerController>();
	}

    void FixedUpdate() //set the correct collider for the direction of the player
    {

		if (player.currentMovement.y > 0.1f)
		{
			colUp.enabled = true;
			colDown.enabled = false;
			colRight.enabled = false;
			colLeft.enabled = false;
		}
		else if (player.currentMovement.y < -0.1f)
		{
			colUp.enabled = false;
			colDown.enabled = true;
			colRight.enabled = false;
			colLeft.enabled = false;
		}

		if (player.currentMovement.x > 0.1f)
		{
			colUp.enabled = false;
			colDown.enabled = false;
			colRight.enabled = true;
			colLeft.enabled = false;
		}
		else if (player.currentMovement.x < -0.1f)
		{
			colUp.enabled = false;
			colDown.enabled = false;
			colRight.enabled = false;
			colLeft.enabled = true;
		}
	}
}
