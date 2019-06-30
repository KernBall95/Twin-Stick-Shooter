using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropPickup : MonoBehaviour {

    public GameObject[] pickups = new GameObject[2];

    private EnemyHealth eHealth;
    private bool dropping;
    private SpawnManager sManager;

    void Start () {
        sManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        eHealth = GetComponent<EnemyHealth>();
        dropping = false;
	}
	
    void Update()
    {
        Debug.Log(eHealth.isDead);
        if (eHealth.isDead && dropping == false)
        {
            DecideIfDrop();
            dropping = true;
            Debug.Log("Deciding...");
        }           
    }
    

    void DecideIfDrop()
    {
        int decider = Random.Range(0, 2);

        if(decider == 0)
        {
            KillCharacter();           
        }
        else if (decider == 1)
        {
            DecidePickup();
        }              
    }

    void DecidePickup()
    {
        int chosenPickup = Random.Range(0, pickups.Length);
        DropPickup(pickups[chosenPickup]);
    }

    void DropPickup(GameObject pickup)
    {
        Instantiate(pickup, transform.position, Quaternion.identity);
        Debug.Log(pickup + " dropped");
        KillCharacter();
    }

    void KillCharacter()
    {
        sManager.spawnedEnemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
