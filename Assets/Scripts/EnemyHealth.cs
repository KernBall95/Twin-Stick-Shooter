using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth;

    private int currentHealth;

	void Start () {
        currentHealth = maxHealth;
	}

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
