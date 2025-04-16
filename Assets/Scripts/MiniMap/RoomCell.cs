using UnityEngine;
using UnityEngine.UI;

public class RoomCell : MonoBehaviour
{
    public Image image;

    private bool _isBossRoom;

    public void SetUnvisited()
    {
        image.color = Color.white;
    }

    public void SetVisited()
    {
        image.color = Color.green;
    }

    public void SetBossRoom()
    {
        image.color = Color.red;
        _isBossRoom = true;
    }

    public void SetPlayerHere()
    {
        image.color = Color.blue;
    }
}
