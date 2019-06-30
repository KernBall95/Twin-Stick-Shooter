using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float speed;
    public float fireRate;

    public void IncreaseSpeed(float addedSpeed)
    {
        speed += addedSpeed;
    }

    public void IncreaseFireRate(float addedFireRate)
    {
        fireRate += addedFireRate;
    }
}
