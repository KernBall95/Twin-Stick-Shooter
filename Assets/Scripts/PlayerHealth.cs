using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;

    [HideInInspector]
    public int currentHealth;

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
