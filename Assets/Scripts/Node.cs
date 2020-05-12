using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Transform pos;
    public Vector2 vector2Pos;
    public List<Node> connections;
    public int connectionCount;

    public void Start()
    {
        connectionCount = connections.Count;
        vector2Pos = new Vector2(transform.position.x, transform.position.y);
    }

}
