using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    private PlayerController player;
    [Header("enemyspawner")]
    [SerializeField]private EnemySpawner enemyspawner;
    public int spawnPoints;

    public RoomController currentRoom;

    public UnityAction onAllEnemiesInRoomDie;
    public UnityAction PlayerEnterRoom;

    public static LevelController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        for (int i = 0; i < spawnPoints; i++)
        {
            float x = Random.Range(5f, 45f);
            float z = Random.Range(5f, 45f);
            enemyspawner.spawnPosition.Add(new Vector3(x,2.2f,z));
        }
    }

    private void Update()
    {
        if (!currentRoom.isAllEnemiesDie)
        {

        }
    }
}
