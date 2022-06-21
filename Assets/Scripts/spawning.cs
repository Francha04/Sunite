 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public spawnManagement manager;
    public GameObject[] spawnersArr;
    public int totalSpawners;
    public GameObject meteorPrefab;
    void Start()
    {
        StartCoroutine("cargarSpawnerArr");
        totalSpawners = manager.numberOfSpawners;
    }

    public IEnumerator cargarSpawnerArr() 
    {
        yield return new WaitForSeconds(0.5f);
        spawnersArr = manager.allSpawnersArray;
        StopCoroutine("cargarSpawnerArr");
    }
    public void spawnMeteor() 
    {
        GameObject newMeteor = Instantiate(meteorPrefab, this.transform.position, new Quaternion(0f,0f,0f,0f), this.transform);
    }
}
