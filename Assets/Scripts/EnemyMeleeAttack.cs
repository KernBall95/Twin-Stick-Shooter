using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAttack : MonoBehaviour {

    public int damage;
    public float attackRate;
    public float delayBeforeAttack;
    public float meleeRange;

    private NavMeshAgent agent;
    private EnemyMoveToPlayer enemyMoveToPlayer;
    private GameObject target;
    private bool readyToAttack;

	void Start () {
        enemyMoveToPlayer = GetComponent<EnemyMoveToPlayer>();
        agent = enemyMoveToPlayer.agent;
        target = enemyMoveToPlayer.target;
        readyToAttack = true;
	}
	
	void Update () {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= meleeRange && readyToAttack == true)
                StartCoroutine(AttackPlayer());
        }  
	}

    IEnumerator AttackPlayer()
    {
        readyToAttack = false;

        yield return new WaitForSeconds(delayBeforeAttack);

        if (agent.remainingDistance > meleeRange)
        {
            yield return new WaitForSeconds(attackRate);
            readyToAttack = true;
        }      
        else
        {
            target.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
            yield return new WaitForSeconds(attackRate);

            readyToAttack = true;
        }
    }
}
