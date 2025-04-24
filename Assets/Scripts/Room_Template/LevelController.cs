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

    private int numOfCards = 0;
    private int numOfRoom = 1;

    private MiniMapManager miniMapManager;

    [HideInInspector]public bool isBossDie;
    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Start()
    {
        miniMapManager = GetComponent<MiniMapManager>();
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
            miniMapManager.PlayerInHere(currentRoom.positionOfRoom);
        }
        if (currentRoom.isAllEnemiesDie && !currentRoom.isReadyToGo)
        {
            onAllEnemiesInRoomDie.Invoke();
            miniMapManager.VisitRoom(currentRoom.positionOfRoom);
            currentRoom.isReadyToGo = true;
            numOfRoom--;
            if (numOfRoom == 0) 
            {
                numOfRoom = 1;
                numOfCards++;
                Debug.Log($"You get a new card, now you have {numOfCards} cards");
                CardSimpleManager.instance.GetACard();
            }
        }
        if (!currentRoom.isAllEnemiesDie && !currentRoom.isPlayerInRoom)
        { 
            currentRoom.CloseAllGates();
        }

        if (isBossDie)
        {
            Debug.Log("You win!! ready to next level!!");
        }
    }
}
