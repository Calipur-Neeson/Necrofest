using UnityEngine;

public class CurrentRoomTracker : MonoBehaviour
{
    private RoomController roomController;
    private EnemySpawner enemyspawner;

    private void Start()
    {
        roomController = GetComponent<RoomController>();
        enemyspawner = FindFirstObjectByType<EnemySpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (roomController != null && !roomController.isAllEnemiesDie)
            {
                LevelController.instance.currentRoom = roomController;
            }
        }
        enemyspawner.transform.SetParent(transform, false);
    }


}
