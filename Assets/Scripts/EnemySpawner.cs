using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("EnemyPool")]
    public GameObject[] enemies;
    [Range(5.0f, 20.0f)]
    public int enemyPoolCapacity;
    public Transform[] spawnPosition;

    private List<GameObject> enemyPool;
    private List<GameObject> enemyWaitingSpawn;

    private void Awake()
    {
        
    }
    private void Start()
    {
        //for (int i = 0; i < enemyPoolCapacity - 1; i++)
        //{
        //    int temp = Random.Range(0, enemies.Length);
        //    enemyWaitingSpawn[i] = Instantiate(enemies[temp]);
        //    enemyWaitingSpawn[i].transform.parent = transform;
        //    enemyWaitingSpawn[i].gameObject.SetActive(false);
        //}
        ////InvokeRepeating(nameof(SpawnEnemy), 1f, 2f);
    }
    
    private void SpawnEnemy()
    {
        if (enemyWaitingSpawn != null)
        {
            int temp = Random.Range(0, enemyWaitingSpawn.Count -1);
            enemyPool.Add(enemyWaitingSpawn[temp]);
            ActiveEnemy(enemyWaitingSpawn[temp]);
            enemyWaitingSpawn.RemoveAt(temp);
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
