using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private EnemySpawner spawner;
    private EnemyKillTracker tracker;

    private void Start()
    {
        spawner = GetComponentInParent<EnemySpawner>();
        tracker = FindObjectOfType<EnemyKillTracker>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        //Debug.Log(gameObject.name + " get " + damage + " damage£¬Remaining HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " Die");
        spawner.WaitingToSpawn(gameObject);
    }
    private void OnDisable()
    {
        if (tracker != null && gameObject.activeInHierarchy == false)
        {
            tracker.OnEnemyKilled(); 
        }
    }
}
