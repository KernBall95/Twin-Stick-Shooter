using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float moveSpeed;
    private Vector3 movementDirection;
    private Vector3 rotation;
    private float xAxis, zAxis, xRot, zRot;
    private Rigidbody rb;
    private PlayerStats pStats;
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pStats = GetComponent<PlayerStats>();
    }

	void FixedUpdate () {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        xRot = Input.GetAxis("Fire1");
        zRot = Input.GetAxis("Fire2");

        rotation = new Vector3(xRot, 0, zRot);
        movementDirection = new Vector3(xAxis, 0, zAxis);
        moveSpeed = pStats.speed;
        rb.velocity = movementDirection * moveSpeed;

        if(Input.GetAxisRaw("Fire1") != 0 || Input.GetAxisRaw("Fire2") != 0)
        {
            RotatePlayer();
        }      
    }

    void RotatePlayer()
    {
        transform.rotation = Quaternion.LookRotation(rotation);
    }
}
