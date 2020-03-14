using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImagePool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrefab;

    // our pool where we store all the objects
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static AfterImagePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    // create more Game object for the pool
    private void GrowPool()
    {
        // create 10 Ga.O
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(afterImagePrefab);
            // set instanceToAdd a child of the Ga.O 
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    // add object to pool
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        // add the ga.o to the queue
        availableObjects.Enqueue(instance);
    }

    // use object from the pool
    public GameObject GetFromPool()
    {
        // if no object, make them
        if (availableObjects.Count == 0)
        {
            GrowPool();
        }

        // took a ga.o from the queue
        var instance = availableObjects.Dequeue();
        instance.SetActive(true);

        return instance;
    }
}
