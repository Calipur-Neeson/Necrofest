using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using AG2187;
public class GunTrigger : MonoBehaviour
{
    private GameObject player;
    private AttackManager attackManager;
    private SphereCollider sphere;
    private float damage;

    [HideInInspector] public bool isRicochet = false;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>().gameObject;
        attackManager = player.GetComponent<AttackManager>();
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
                attackManager.CalculateHitDamage();
                damage = attackManager.rangeDamage;
                enemyHealth.TakeDamage(damage,"Gun");
            }
            if (isRicochet)
            {
                Collider[] hitCollider = Physics.OverlapSphere(other.transform.position, 2.0f);
                List<GameObject> nearByEnemies = new List<GameObject>();
                foreach (Collider col in hitCollider)
                {
                    if (col.CompareTag("Enemy") && col.gameObject !=other)
                    {
                        nearByEnemies.Add(col.gameObject);
                    }
                }
                if (nearByEnemies.Count > 2)
                {
                    nearByEnemies.Sort((a, b) =>
                        Vector3.Distance(a.transform.position, other.transform.position)
                        .CompareTo(Vector3.Distance(b.transform.position, other.transform.position)));
                    for (int i = 0; i < 2; i++)
                    {
                        RicochetEnemy(nearByEnemies[i], damage);
                    }
                }
                else
                {
                    for (int i = 0; i < nearByEnemies.Count; i++)
                    { RicochetEnemy(nearByEnemies[i], damage); }
                }

            }
        }
    }

    private void RicochetEnemy(GameObject enemy, float da)
    {
        EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
        eh.TakeDamage(da, "");
    }
}
