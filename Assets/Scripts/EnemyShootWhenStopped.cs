using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShootWhenStopped : MonoBehaviour {

    public GameObject target;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float projectileSpeed;
    public float fireRate;

    private NavMeshAgent agent;
    private EnemyMoveToPlayer enemyMoveToPlayer;
    private bool isShooting;

	void Start () {
        enemyMoveToPlayer = GetComponent<EnemyMoveToPlayer>();
        agent = enemyMoveToPlayer.agent;
        target = enemyMoveToPlayer.target;
        isShooting = false;
	}
	
	void Update () {
        transform.LookAt(target.transform);
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
               // if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                //{
                    
                    if (isShooting == false)
                        StartCoroutine(ShootTarget());
               // }
            }
        }
	}

    IEnumerator ShootTarget()
    {
        isShooting = true;
        
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        Debug.Log("Shot at " + target);
        yield return new WaitForSeconds(fireRate);

        isShooting = false;
    }
}
