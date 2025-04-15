using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomSpawner : MonoBehaviour
{
    public RoomController roomTemplate;
    public RoomController bossRoom;
    public int roomCount;
    public LevelController levelController;

    private float gridSize = 65;
    enum Direction
    {
        Down = 1,
        Up = 2,
        Left = 3,
        Right = 4,
    }

    [HideInInspector]public int mapSize = 4;
    private int[,] grid;
    private int startPointX;
    private int startPointY;
    private int ran;

    private Vector3 position;
    private bool runSpawner = true;
    [SerializeField] private RoomController currentRoomController;
    private MiniMapManager miniMapManager;
    private void Start()
    {
        //gridSize = roomTemplate.GetRoomSize();
        grid = new int[mapSize, mapSize];
        startPointX = (int) (mapSize/2);
        startPointY = (int) (mapSize/2);
        currentRoomController.positionOfRoom = new Vector2Int(startPointX, startPointY);

        position = new Vector3(0,0,0);
        grid[startPointX, startPointY] = 1;

        miniMapManager = GetComponent<MiniMapManager>();

        InvokeRepeating(nameof(InstantiateRoom), 0.5f, 0.5f);
            //Invoke(nameof(InstantiateRoom), 0.2f);
            //InstantiateRoom();

    }

    void InstantiateRoom()
    {
        List<Direction> dirs = new List<Direction>();
        if(startPointY > 0)
            if (grid[startPointX, startPointY - 1] == 0)
            {
                dirs.Add(Direction.Down);
            }
        if (startPointY < mapSize - 1)
            if (grid[startPointX, startPointY + 1] == 0)
            {
                dirs.Add(Direction.Up);
            }
        if (startPointX > 0)
            if (grid[startPointX - 1, startPointY] == 0)
            {
                dirs.Add(Direction.Left);
            }
        if (startPointX < mapSize - 1)
            if (grid[startPointX + 1, startPointY] == 0)
            {
                dirs.Add(Direction.Right);
            }

        if (dirs.Count == 0)
        {
            runSpawner = false;
            Debug.Log("Finish spawning");
            CancelInvoke(nameof(InstantiateRoom));
            currentRoomController.gameObject.SetActive(false);
            Destroy(currentRoomController);
            currentRoomController = Instantiate(bossRoom, new Vector3(gridSize * (startPointX - (int)mapSize / 2), 0, gridSize * (startPointY - (int)mapSize / 2)), Quaternion.identity);
            currentRoomController.positionOfRoom = new Vector2Int(startPointX, startPointY);
            miniMapManager.SetBossRoom(currentRoomController.positionOfRoom);
            switch (ran)
            {
                case 1:
                    currentRoomController.OpenGate(1);
                    break;
                case 2:
                    currentRoomController.OpenGate(2);
                    break;
                case 3:
                    currentRoomController.OpenGate(3);
                    break;
                case 4:
                    currentRoomController.OpenGate(4);
                    break;
            }

            FillUpRooms();
            return;
        }
        ran = Random.Range(0, dirs.Count);

        currentRoomController.OpenGate((int)dirs[ran]);
        switch (dirs[ran])
        {
            case Direction.Down:
                startPointY--;
                Debug.Log("Down");
                break;
            case Direction.Up:
                Debug.Log("Up");
                startPointY++;
                break;
            case Direction.Left:
                Debug.Log("Left");
                startPointX--;
                break;
            case Direction.Right:
                Debug.Log("Right");
                startPointX++;
                break;
        }
        grid[startPointX, startPointY] = 1;
        currentRoomController = Instantiate(roomTemplate, new Vector3(gridSize * (startPointX - (int) mapSize/2), 0, gridSize * (startPointY - (int)mapSize / 2)), Quaternion.identity);
        currentRoomController.OpenRandomGate();
        currentRoomController.positionOfRoom = new Vector2Int(startPointX, startPointY);
        switch (dirs[ran])
        {
            case Direction.Down:
                currentRoomController.OpenGate((int)Direction.Up);
                break;
            case Direction.Up:
                currentRoomController.OpenGate((int)Direction.Down);
                break;
            case Direction.Left:
                currentRoomController.OpenGate((int)Direction.Right);
                break;
            case Direction.Right:
                currentRoomController.OpenGate((int)(Direction.Left));
                break;
        }
    }

    private void FillUpRooms()
    {
        for(int x = 0; x < mapSize;  x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                if (grid[x, y] == 0)
                {
                    RoomController newRoom = Instantiate(roomTemplate, new Vector3(gridSize * (x - (int)mapSize / 2), 0, gridSize * (y - (int)mapSize / 2)), Quaternion.identity);
                    newRoom.positionOfRoom = new Vector2Int(x, y);
                }
            }
        }
    }
}
