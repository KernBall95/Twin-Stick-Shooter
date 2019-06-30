using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float projectileSpeed;

    private float fireSpeed;
    private Vector3 fireDirection;
    private float xAxis, zAxis;
    private bool firing = false;
    private PlayerStats pStats;

    void Start()
    {
        pStats = GetComponent<PlayerStats>();
    }

	void Update () {
        xAxis = Input.GetAxis("Fire1");
        zAxis = Input.GetAxis("Fire2");

        fireDirection = new Vector3(xAxis, 0, zAxis);
        
        if (firing == false)
        {
            if (Input.GetAxisRaw("Fire1") != 0 || Input.GetAxisRaw("Fire2") != 0)
            {
                StartCoroutine(FireProjectile());
            }
        }
	}

    IEnumerator FireProjectile()
    {
        firing = true;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(fireDirection.normalized * projectileSpeed);

        fireSpeed = pStats.fireRate;
        yield return new WaitForSeconds(fireSpeed);
        firing = false;    
    }
}
