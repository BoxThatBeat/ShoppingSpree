using System.Collections.Generic;
using UnityEngine;

public class CPU_Generator : MonoBehaviour
{
    public List<Node> nodes;
    public List<CPU_Controller> cpuPrefabs;

    private Node NextNode;
    private List<CPU_Controller> cpuInstances = new List<CPU_Controller>();


    void Start() //Instantiate all the CPUs
    {
        for (int i = 0; i < 1; i++)
        {
            NextNode = nodes[Random.Range(0, nodes.Count)]; //start node of the cpu
            var instance = Instantiate(cpuPrefabs[Random.Range(0, cpuPrefabs.Count)], NextNode.pos.position, Quaternion.identity) as CPU_Controller;//make a cpu at random position and random prefab
            instance.currentNode = NextNode;
            instance.nextPosition = instance.currentNode.connections[Random.Range(0, instance.currentNode.connectionCount)].pos; //set the next node to a randomly selected node in the node's connections
            cpuInstances.Add(instance); //add cpu to the list of cpus for use in Update()
        }
        
    }


    void Update()
    {
        foreach (var cpu in cpuInstances) //iteration over all instantiated CPUs
        {
            if (cpu.readyToMove) //if the cpu is ready for next waypoint node
            {
                NextNode = cpu.currentNode.connections[Random.Range(0, cpu.currentNode.connectionCount)];
                cpu.nextPosition = NextNode.pos; //set the next pos
                cpu.currentNode = NextNode;
                cpu.readyToMove = false;
            }
        }
    }
}
