using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    private float health;
    private EnemySpawner spawner;
    private EnemyKillTracker tracker;

    [Header("DropIterm")]
    [SerializeField] private int chanceToDrop;
    public List<BaseWeapon> weapons;

    private string lastDamageSource;

    private void Start()
    {
        health = enemyHealth;
        spawner = GetComponentInParent<EnemySpawner>();
        tracker = FindFirstObjectByType<EnemyKillTracker>();
    }
    public void TakeDamage(float damage, string weaponType)
    {
        health -= damage;
        Debug.Log(gameObject.name + " get " + damage + "by " +weaponType + " damage£¬Remaining HP: " + health);

        if (health < 1e-6f)
        {
            lastDamageSource = weaponType;
            Die();
        }
        if (tracker.isMercy)
        {
            if (health < enemyHealth * 0.1f)
            {
                lastDamageSource = weaponType;
                Die();
                Debug.Log("Killed by Mercy~~~");
            }
        }
    }

    void Die()
    {
        //Debug.Log(gameObject.name + " Die");
        spawner.WaitingToSpawn(gameObject);
        Vector3 pos = transform.position ;
        //gameObject.SetActive(false);
        int chance = Random.Range(0, 100);
        if(chance<chanceToDrop)
        {
            int x = Random.Range(0, weapons.Count);
            Instantiate(weapons[x], pos ,Quaternion.identity);
        }
    }
    private void OnDisable()
    {
        if (tracker != null && gameObject.activeInHierarchy == false)
        {
            tracker.OnEnemyKilled(lastDamageSource); 
        }
    }

    public void RestEnemyHealth()
    {
        health = enemyHealth;
    }
}
