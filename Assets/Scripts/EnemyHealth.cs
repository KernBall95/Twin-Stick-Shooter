using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

	void Start () {
        currentHealth = maxHealth;
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= 1;

        if (currentHealth <= damage)
            Destroy(gameObject);
    }



}
