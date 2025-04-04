using UnityEngine;

public class CurrentRoomTracker : MonoBehaviour
{
    private RoomController roomController;

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
            }
        }
    }
}
