using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using AG2187;
public class RoomController : MonoBehaviour
{
    [Header("Gate Controller")]
    [SerializeField] GameObject[] frontGate;
    [SerializeField] GameObject[] backGate;
    [SerializeField] GameObject[] leftGate;
    [SerializeField] GameObject[] rightGate;

    [Header("Room Properties")]
    [SerializeField] private TerrainCollider terrainCollider;


    public bool isAllEnemiesDie = false;
    public bool isPlayerInRoom = false;
    public bool isReadyToGo = false;
    public List<GameObject> willOpenGates = new List<GameObject>();
    public List<GameObject> enemiesInRoom = new();

    [SerializeField] private GameObject point;
    public List<Transform> spawnerPoints = new();

    public Vector2Int positionOfRoom;
    private void Start()
    {
        OpenRandomGate();
        LevelController.instance.onPlayerEnterRoom += CloseAllGates;
        LevelController.instance.onAllEnemiesInRoomDie += OpenGatesTONextRoom;
        for (int i = 0; i < LevelController.instance.spawnPoints; i++)
        {
            GameObject emptyObject = Instantiate(point, transform);
            float x = Random.Range(5f, 45f);
            float z = Random.Range(5f, 45f);
            emptyObject.transform.localPosition = new Vector3(x, 2.2f, z);
            spawnerPoints.Add(emptyObject.transform);
        }
    }

    public void OpenGate(int dir)
    {
        switch (dir)
        {
            case 1:
                foreach(GameObject gate in backGate)
                {
                    gate.SetActive(false);
                    willOpenGates.Add(gate);
                }
                break;
            case 2:
                foreach (GameObject gate in frontGate)
                {
                    gate.SetActive(false);
                    willOpenGates.Add(gate);
                }
                break;
            case 3:
                foreach (GameObject gate in leftGate)
                {
                    gate.SetActive(false);
                    willOpenGates.Add(gate);
                }
                break;
            case 4:
                foreach (GameObject gate in rightGate)
                {
                    gate.SetActive(false);
                    willOpenGates.Add(gate);
                }
                break;
        }
    }
    public void OpenGatesTONextRoom()
    {
        foreach (GameObject gate in willOpenGates)
        {
            gate.SetActive(false);
        }
    }
    public void CloseAllGates()
    {
        foreach (GameObject gate in backGate) { gate.SetActive(true);}
        foreach (GameObject gate in frontGate) { gate.SetActive(true);}
        foreach (GameObject gate in leftGate) { gate.SetActive(true);}
        foreach (GameObject gate in rightGate) { gate.SetActive(true);}
    }
    public float GetRoomSize()
    {
        return terrainCollider.bounds.size.x;
    }

    public void OpenRandomGate()
    {
        int x = Random.Range(1, 5);
        OpenGate(x);
    }

    public void SpawnEnemy()
    {
        // Add this one to the enemiesInRoom list
    }

    //public void KillEnemy(GameObject enemy)
    //{
    //    if (enemiesInRoom.Contains(enemy))
    //    {
    //        enemiesInRoom.Remove(enemy);
    //    }
    //
    //    if (enemiesInRoom.Count == 0)
    //    {
    //        LevelController.instance.onAllEnemiesInRoomDie.Invoke();
    //        isAllEnemiesDie = true;
    //    }
    //}
}
