using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    private float health;
    private EnemySpawner spawner;
    private EnemyKillTracker tracker;

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
        Debug.Log(gameObject.name + " get " + damage + " damage£¬Remaining HP: " + health);

        if (health < 1e-6f)
        {
            lastDamageSource = weaponType;
            Die();
        }
    }

    void Die()
    {
        //Debug.Log(gameObject.name + " Die");
        spawner.WaitingToSpawn(gameObject);
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
