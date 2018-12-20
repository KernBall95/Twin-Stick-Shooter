using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;

    Vector3 movementDirection;
    float xAxis, zAxis;
    Rigidbody rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Update () {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        movementDirection = new Vector3(xAxis, 0, zAxis);
        rb.velocity = movementDirection * moveSpeed;
    }
}
