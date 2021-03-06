﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ObjectPool : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDict; //dictionary that stores queues that are object pools

    private void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.gameObject.transform.parent = gameObject.transform;//set objects to be children of this pooler
                obj.SetActive(false);
                objPool.Enqueue(obj);

            }

            poolDict.Add(pool.tag, objPool);
        }

        //after all the pools have been loaded, get the lights in the children created
        GetComponent<LightSwitch>().SetupChildren();
    }

    public GameObject SpawnFromPool (string tag, Vector2 pos, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist.");
            return null;
        }

        GameObject objToSpawn = poolDict[tag].Dequeue();

        objToSpawn.transform.position = pos;
        objToSpawn.transform.rotation = rotation;
        objToSpawn.SetActive(true);

        poolDict[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

}
