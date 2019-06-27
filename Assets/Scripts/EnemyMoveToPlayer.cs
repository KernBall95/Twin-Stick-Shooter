using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToPlayer : MonoBehaviour {

    public GameObject target;

    private NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Temp Player");
        agent.speed = Random.Range(16, 20);
	}
	
	void Update () {
        agent.destination = target.transform.position;
	}
}
