using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestruct : MonoBehaviour {

	void Start () {
        StartCoroutine(SelfDestruct());
	}

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
