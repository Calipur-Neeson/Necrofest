using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float enemyHealth = 500f;
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
        Debug.Log(gameObject.name + " get " + damage + "by " + weaponType + " damage£¬Remaining HP: " + health);

        if (health < 1e-6f)
        {
            lastDamageSource = weaponType;
            Die();
        } 
    }

    void Die()
    {
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        if (tracker != null && gameObject.activeInHierarchy == false)
        {
            tracker.OnEnemyKilled(lastDamageSource);
        }
    }
}
