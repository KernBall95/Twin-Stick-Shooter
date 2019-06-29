using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour {

    public GameObject bulletDeathParticles;

    private string bulletName;

    void Start()
    {
        bulletName = gameObject.name;
        StartCoroutine(DestroyBullet());
    }

	IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (bulletName == "Bullet(Clone)")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(1);
            }
        }
        else if (bulletName == "EnemyBullet(Clone)")
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(1);
            }
        }
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(bulletDeathParticles, pos, rot);
            Destroy(gameObject);       
    }
}
