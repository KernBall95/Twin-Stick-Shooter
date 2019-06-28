using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;

    private int currentHealth;

	void Start () {
        currentHealth = maxHealth;
	}

    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
            Destroy(gameObject);
    }
}
