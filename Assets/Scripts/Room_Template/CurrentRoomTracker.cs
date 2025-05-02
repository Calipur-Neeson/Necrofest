using UnityEngine;

namespace AG2187
{
    public class CurrentRoomTracker : MonoBehaviour
    {
        private RoomController roomController;
        private EnemySpawner enemyspawner;
        private MiniMapManager miniMapManager;

        private void Start()
        {
            roomController = GetComponent<RoomController>();
            enemyspawner = FindFirstObjectByType<EnemySpawner>();
            miniMapManager = FindFirstObjectByType<MiniMapManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (roomController != null && !roomController.isAllEnemiesDie)
                {
                    LevelController.instance.currentRoom = roomController;
                }
                enemyspawner.transform.SetParent(transform, false);
                roomController.isPlayerInRoom = true;
                //miniMapManager.VisitRoom(roomController.positionOfRoom);
            }
        }


    } 
}
