using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] enemySpawnsArray;
    public int spawnCount;
    public GameObject enemy;
    public float spawnRate;

	void Start () {
        FindSpawnPoints();
        StartCoroutine(SpawnEnemies());
	}
	
	void Update () {
		
	}

    void FindSpawnPoints()
    {
        enemySpawnsArray = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            enemySpawnsArray[i] = transform.GetChild(i);
            Debug.Log(enemySpawnsArray[i]);
        }
    }

    IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemy, enemySpawnsArray[Random.Range(0, transform.childCount - 1)].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
