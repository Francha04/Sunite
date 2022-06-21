using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class spawnManagement : MonoBehaviour
{
        // Will contain all the spawners.
    public int numberOfSpawners;  // Inspector. Amount of spawners.
    //public GameObject parentSpawner;     // The Game Object that manages all the spawns.
    public int maxMeteors;
    public bool spawnEnabled;
    public int amountOfMeteors;
    public GameObject[] allSpawnersArray;
    public float timeBetweenSpawns = 3f;
    void Start()
    {
        allSpawnersArray = new GameObject[this.transform.childCount];
        spawnEnabled = true;
        amountOfMeteors = 0;
        for (int i = 0; i < numberOfSpawners; i++) 
        {
            allSpawnersArray[i] = this.transform.GetChild(i).gameObject;
        }
        StartCoroutine("SpawnMeteorR");
    }

    public IEnumerator SpawnMeteorR() 
    {
        while (spawnEnabled)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            if (amountOfMeteors < maxMeteors + 1) 
            {
                int randomIndex = (int)Random.Range(0, numberOfSpawners - 1);
                GameObject spawnerToSpawn = allSpawnersArray[randomIndex];
                amountOfMeteors++;
                spawning spawnMeteorManager = spawnerToSpawn.GetComponent<spawning>();
                spawnMeteorManager.spawnMeteor();   
            }
            

        }
    }
}
