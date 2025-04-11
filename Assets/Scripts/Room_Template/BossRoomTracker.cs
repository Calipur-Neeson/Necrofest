using UnityEngine;

public class BossRoomTracker : MonoBehaviour
{
    private RoomController roomController;
    [SerializeField] private GameObject boss;
    private void Start()
    {
        roomController = GetComponent<RoomController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (roomController != null && !roomController.isAllEnemiesDie)
            {
                LevelController.instance.currentRoom = roomController;
                boss.gameObject.SetActive(true);
            }

            roomController.isPlayerInRoom = true;
        }
    }
}
