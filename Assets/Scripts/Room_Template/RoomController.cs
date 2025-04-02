using UnityEngine;

public class RoomController : MonoBehaviour
{
    [Header("Gate Controller")]
    [SerializeField] GameObject[] frontGate;
    [SerializeField] GameObject[] backGate;
    [SerializeField] GameObject[] leftGate;
    [SerializeField] GameObject[] rightGate;

    [Header("Room Properties")]
    [SerializeField] private TerrainCollider terrainCollider;
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
                }
                break;
            case 2:
                foreach (GameObject gate in frontGate)
                {
                    gate.SetActive(false);
                }
                break;
            case 3:
                foreach (GameObject gate in leftGate)
                {
                    gate.SetActive(false);
                }
                break;
            case 4:
                foreach (GameObject gate in rightGate)
                {
                    gate.SetActive(false);
                }
                break;
        }
    }

    public float GetRoomSize()
    {
        return terrainCollider.bounds.size.x;
    }

    public void OpenRandomGate()
    {
        OpenGate(Random.Range(1, 5));
    }
}
