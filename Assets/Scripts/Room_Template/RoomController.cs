using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    [Header("Gate Controller")]
    [SerializeField] GameObject[] frontGate;
    [SerializeField] GameObject[] backGate;
    [SerializeField] GameObject[] leftGate;
    [SerializeField] GameObject[] rightGate;

    [Header("Room Properties")]
    [SerializeField] private TerrainCollider terrainCollider;

    private LevelController levelController;
    private EnemySpawner enemyspawner;

    public bool isAllEnemiesDie = false;
    public List<GameObject> willOpenGates = new List<GameObject>();
    public List<GameObject> enemiesInRoom = new();
    private void Start()
    {
        OpenRandomGate();
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

    public void KillEnemy(GameObject enemy)
    {
        if (enemiesInRoom.Contains(enemy))
        {
            enemiesInRoom.Remove(enemy);
        }

        if (enemiesInRoom.Count == 0)
        {
            LevelController.instance.onAllEnemiesInRoomDie.Invoke();
            isAllEnemiesDie = true;
        }
    }
}
