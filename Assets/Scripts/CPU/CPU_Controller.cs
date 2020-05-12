using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Controller : MonoBehaviour
{
    public Node currentNode;
    public Transform nextPosition;
    public Vector3 nextVector;
    public bool readyToMove = false;
    public Vector3 movement;
    public Animator anim;

    private float speed = 2.0f;


    private void Start()
    {
        anim = gameObject.GetComponent(typeof(Animator)) as Animator;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x != nextPosition.position.x && transform.position.y != nextPosition.position.y) //if the cpu is not at the next waypoint, start moving to it
        {
            nextVector = new Vector3(nextPosition.position.x, nextPosition.position.y, 0.0f);//make the vector for the point to move to
            transform.position = Vector3.MoveTowards(transform.position, nextVector, speed * Time.deltaTime); //move towards that vector

            Vector3 movement = nextVector - transform.position;

            readyToMove = false;
        }
        else
        {
            print("at destination");
            StartCoroutine("Waiter");
        }


        //Animation

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        readyToMove = true;
    }

}
