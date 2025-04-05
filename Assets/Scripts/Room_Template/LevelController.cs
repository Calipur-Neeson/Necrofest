using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [Header("enemyspawner")]   
    [SerializeField]private EnemySpawner enemySpawner;
    public int spawnPoints;


    public RoomController currentRoom;

    public UnityAction onAllEnemiesInRoomDie;
    public UnityAction onPlayerEnterRoom;

    public static LevelController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Start()
    {
        
        //NewSpawnPoints();
        onPlayerEnterRoom += NewSpawnPoints;

    }
    void NewSpawnPoints()
    {
        enemySpawner.spawnPosition.Clear();
        for (int i = 0; i < spawnPoints; i++)
        {
            enemySpawner.spawnPosition.Add(currentRoom.spawnerPoints[i].transform);
        }
    }
    private void Update()
    {
        if (!currentRoom.isAllEnemiesDie && currentRoom.isPlayerInRoom)
        {
            onPlayerEnterRoom.Invoke();
            enemySpawner.StartTOSpawn();
            currentRoom.isPlayerInRoom = false;
        }
        if (currentRoom.isAllEnemiesDie && !currentRoom.isReadyToGo)
        {
            onAllEnemiesInRoomDie.Invoke();
            currentRoom.isReadyToGo = true;
        }
        if (!currentRoom.isAllEnemiesDie && !currentRoom.isPlayerInRoom)
        { 
            currentRoom.CloseAllGates();
        }
    }
}
