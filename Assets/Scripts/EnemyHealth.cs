using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    //private EnemyPool enemypool;
    private EnemySpawner spawner;

    private void Start()
    {
        //enemypool = GetComponentInParent<EnemyPool>();
        spawner = GetComponentInParent<EnemySpawner>();
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
        //enemypool.ReturnToPool(gameObject);
        spawner.WaitingToSpawn(gameObject);
    }
}
