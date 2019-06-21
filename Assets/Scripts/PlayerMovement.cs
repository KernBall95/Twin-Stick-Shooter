using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;

    Vector3 movementDirection;
    Vector3 rotation;
    private float xAxis, zAxis, xRot, zRot;
    Rigidbody rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        xRot = Input.GetAxis("Fire1");
        zRot = Input.GetAxis("Fire2");

        rotation = new Vector3(xRot, 0, zRot);
        movementDirection = new Vector3(xAxis, 0, zAxis);
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
