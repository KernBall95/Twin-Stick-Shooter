using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToPlayer : MonoBehaviour {

    public GameObject target;
    public bool variableSpeedEnabled;
    public float minSpeed, maxSpeed;
    public NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Temp Player");

        if(variableSpeedEnabled)
            agent.speed = Random.Range(minSpeed, maxSpeed);
	}
	
	void Update () {
        agent.destination = target.transform.position;
	}
}
