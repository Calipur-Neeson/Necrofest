using System.Collections.Generic;
using UnityEngine;

namespace AG2187
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("EnemyPool")]
        public GameObject[] enemies;
        [Range(1.0f, 40.0f)]
        public int enemyPoolCapacity;
        [Range(2.0f, 10.0f)]
        public float intervalTime;
        public List<Transform> spawnPosition = new();

        private List<GameObject> enemyPool = new List<GameObject>();
        private List<GameObject> enemyWaitingSpawn = new List<GameObject>();
        private List<GameObject> enemyDie = new List<GameObject>();

        private EnemyHealth eh;

        private void Start()
        {
            for (int i = 0; i < enemyPoolCapacity; i++)
            {
                int temp = Random.Range(0, enemies.Length);
                GameObject enemy = Instantiate(enemies[temp], transform);

                enemy.SetActive(false);
                enemyWaitingSpawn.Add(enemy);
            }
            InvokeRepeating(nameof(SpawnEnemy), 1f, intervalTime);
        }
        private void Update()
        {
            if (enemyDie.Count == enemyPoolCapacity)
            {
                //RoomController currentRoom = GetComponentInParent<RoomController>();
                //currentRoom.isAllEnemiesDie = true;
                //CancelInvoke(nameof(SpawnEnemy));
                for (int i = enemyDie.Count - 1; i >= 0; i--)
                {
                    enemyWaitingSpawn.Add(enemyDie[i]);
                    enemyDie.RemoveAt(i);
                }
            }
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
            int temp = Random.Range(0, spawnPosition.Count);
            gb.transform.position = spawnPosition[temp].position;
            eh = gb.GetComponent<EnemyHealth>();
            eh.RestEnemyHealth();
            gb.SetActive(true);
        }

        public void WaitingToSpawn(GameObject gb)
        {
            gb.gameObject.SetActive(false);
            enemyDie.Add(gb);
            enemyPool.Remove(gb);
        }

        public void StartTOSpawn()
        {
            InvokeRepeating(nameof(SpawnEnemy), 1f, intervalTime);
        }
    } 
}
