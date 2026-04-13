using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;
    public int maxObjects = 3;

    private int currentObjects = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (currentObjects >= maxObjects)
            return;

        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        currentObjects++;
    }
}