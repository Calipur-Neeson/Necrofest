using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SphereCollider sphere;
    public float damage = 100f;
    private void Start()
    {
        sphere = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //int layer = other.gameObject.layer;
        if (other.CompareTag("Enemy"))
        {
            sphere.enabled = false;
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, "Gun");
            }
        }
    }
}
