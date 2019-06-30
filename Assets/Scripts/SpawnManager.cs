using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
 
    public int spawnCount;
    public GameObject[] enemy;
    public float spawnRate;
    public int waveIncrement;

    //[HideInInspector]
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private Transform[] enemySpawnsArray;
    private GameObject spawnedEnemy;
    

    void Start () {
        FindSpawnPoints();
        StartCoroutine(SpawnEnemies());
	}

    void Update()
    {
        if(spawnedEnemies.Count == 0)
        {
            spawnCount += waveIncrement;
            StartCoroutine(SpawnEnemies());
        }
    }

    void FindSpawnPoints()
    {
        enemySpawnsArray = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            enemySpawnsArray[i] = transform.GetChild(i);
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            spawnedEnemy = Instantiate(enemy[Random.Range(0,3)], enemySpawnsArray[Random.Range(0, transform.childCount - 1)].position, Quaternion.identity) as GameObject;
            spawnedEnemies.Add(spawnedEnemy);
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
}
