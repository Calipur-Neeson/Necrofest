using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [Header("EnemyPool")]
    public GameObject[] enemies;
    //[Range(10.0f, 20.0f)]
    public int enemyPoolCapacity;

    private ObjectPool<GameObject> enemyPool;
    public Transform[] spawnPosition;
    private bool collectionCheck = true;

    private void Awake()
    {
        enemyPool = new ObjectPool<GameObject>(CreateGO, TakenFromPool, ReturnToPool, DistroyPoolObject, collectionCheck, 5, 10);
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            enemyPool.Release(CreateGO());
        }
        InvokeRepeating(nameof(SpawnEnemy), 1f, 2f);
    }
    private void SpawnEnemy()
    {
        GameObject enemy = enemyPool.Get();
    }
    private GameObject CreateGO()
    {
        int temp = Random.Range(0, enemies.Length);
        GameObject newEnemy = Instantiate(enemies[temp]);
        newEnemy.transform.parent = transform;
        return newEnemy;
    }

    private void TakenFromPool(GameObject gb)
    {
        int temp = Random.Range(0, spawnPosition.Length);
        gb.transform.position = spawnPosition[temp].position;
        gb.SetActive(true);
    }

    public void ReturnToPool(GameObject gb)
    {
        gb.gameObject.SetActive(false);
        //enemyPool.Release(gb);
    }

    private void DistroyPoolObject(GameObject gb)
    {
        Destroy(gb.gameObject);
    }
        
}

