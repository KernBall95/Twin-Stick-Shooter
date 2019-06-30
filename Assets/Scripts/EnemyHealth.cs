using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth;
    public bool isDead;

    private int currentHealth;
    
	void Start () {
        isDead = false;
        currentHealth = maxHealth;
	}

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            isDead = true;                         
    }
}
