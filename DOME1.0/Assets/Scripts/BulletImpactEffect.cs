using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactEffect : MonoBehaviour
{
    public GameObject impactEffectPrefab;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
        // Instantiate impact effect
        Instantiate(impactEffectPrefab, transform.position, transform.rotation);

        // Destroy the bullet no matter what it hits
       
    }
}
