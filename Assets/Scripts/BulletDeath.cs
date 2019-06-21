﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour {

    public GameObject bulletDeathParticles;

    private Rigidbody rb;
    private Vector3 particleSpawnRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        particleSpawnRotation = rb.velocity;
        StartCoroutine(DestroyBullet());
    }

	IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {
            Debug.Log(other.gameObject.tag);
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject particleEffect = Instantiate(bulletDeathParticles, pos, rot);
            Destroy(gameObject);
        }
    }
}