using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour {

    public float speedIncrease;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().IncreaseSpeed(speedIncrease);
            Destroy(this.gameObject);
        }
    }
}
