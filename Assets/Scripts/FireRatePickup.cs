using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : MonoBehaviour {

    public float fireRateIncrease;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().IncreaseFireRate(fireRateIncrease);
            Destroy(this.gameObject);
        }
    }
}
