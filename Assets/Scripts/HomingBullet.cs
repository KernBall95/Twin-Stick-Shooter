using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour {

    public float maxVelocity;
    public float maxForce;

    private GameObject target;
    private Rigidbody rb;
    private Vector3 velocity;

	void Start () {
        
        target = GameObject.Find("Temp Player");
        rb = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
	}
	
	void Update () {
        Vector3 desiredVelocity = target.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * maxVelocity;

        Vector3 steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(velocity + steering, maxForce);
        steering /= rb.mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, maxVelocity);
        transform.position += velocity * Time.deltaTime;  
	}
}
