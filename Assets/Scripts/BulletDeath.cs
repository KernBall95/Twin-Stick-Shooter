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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(bulletName);
        if (bulletName == "Bullet(Clone)")
        {
            Debug.Log("Player shot!");
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("Player hit enemy!");
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
