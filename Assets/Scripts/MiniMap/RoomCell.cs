using UnityEngine;
using UnityEngine.UI;

public class RoomCell : MonoBehaviour
{
    public Image image;

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
    }

    public void SetPlayerHere()
    {
        image.color = Color.blue;
    }
}
