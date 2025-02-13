using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("EnemyPool")]
    public GameObject[] enemies;
    [Range(5.0f, 20.0f)]
    public int enemyPoolCapacity;
    public Transform[] spawnPosition;

    private List<GameObject> enemyPool = new List<GameObject>();
    private List<GameObject> enemyWaitingSpawn = new List<GameObject>();

    private void Start()
    {

        for (int i = 0; i < enemyPoolCapacity; i++)
        {
            int temp = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[temp], transform);

            enemy.SetActive(false);
            enemyWaitingSpawn.Add(enemy);
            //enemyWaitingSpawn[i] = Instantiate(enemies[temp], transform);
            //enemyWaitingSpawn[i].transform.parent = transform;
            //enemyWaitingSpawn[i].gameObject.SetActive(false);
        }
        InvokeRepeating(nameof(SpawnEnemy), 1f, 2f);
    }
    
    private void SpawnEnemy()
    {
        if (enemyWaitingSpawn != null)
        {
            if (enemyWaitingSpawn.Count != 0)
            {
                int temp = Random.Range(0, enemyWaitingSpawn.Count);
                enemyPool.Add(enemyWaitingSpawn[temp]);
                ActiveEnemy(enemyWaitingSpawn[temp]);
                enemyWaitingSpawn.RemoveAt(temp);
            }
        }
    }
    private void ActiveEnemy(GameObject gb)
    {
        int temp = Random.Range(0, spawnPosition.Length);
        gb.transform.position = spawnPosition[temp].position;
        gb.SetActive(true);
    }

    public void WaitingToSpawn(GameObject gb)
    {
        gb.gameObject.SetActive(false);
        enemyWaitingSpawn.Add(gb);
        enemyPool.Remove(gb);
    }
}
