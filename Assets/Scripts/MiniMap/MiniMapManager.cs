using UnityEngine;
using UnityEngine.UI;

namespace AG2187
{
    public class MiniMapManager : MonoBehaviour
    {
        public GameObject cellPrefab;
        public Transform gridParent;
        [SerializeField] private int width = 4;
        [SerializeField] private int height = 4;

        private RoomSpawner roomSpawner;
        private RoomCell[,] cells;
        private Vector2Int playerPos;

        public Vector2Int bossRoom;

        [Header("References")]
        public RectTransform miniMapPoint_1;
        public RectTransform miniMapPoint_2;
        public Transform worldPoint_1;
        public Transform worldPoint_2;

        [Header("Player")]
        public RectTransform playerMiniMap;
        public Transform playerWorld;

        private float miniMapRatio;

        private void Awake()
        {
            CalculateMapRatio();
            roomSpawner = GetComponent<RoomSpawner>();
            width = roomSpawner.mapSize;
            height = roomSpawner.mapSize;
            GenerateMap();
        }

        private void Update()
        {
            playerMiniMap.anchoredPosition = miniMapPoint_1.anchoredPosition + new Vector2((playerWorld.position.x - worldPoint_1.position.x) *
                miniMapRatio, (playerWorld.position.z - worldPoint_1.position.z) * miniMapRatio);
        }
        public void GenerateMap()
        {
            cells = new RoomCell[width, height];

            foreach (Transform child in gridParent)
                Destroy(child.gameObject);

            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    GameObject obj = Instantiate(cellPrefab, gridParent);
                    RoomCell cell = obj.GetComponent<RoomCell>();
                    cell.SetUnvisited();
                    cells[x, y] = cell;
                }
            }
        }

        public void CalculateMapRatio()
        {
            Vector3 distanceWorldVector = worldPoint_1.position - worldPoint_2.position;
            distanceWorldVector.y = 0f;
            float distanceWorld = distanceWorldVector.magnitude;

            float distanceMiniMap = Mathf.Sqrt(
                Mathf.Pow((miniMapPoint_1.anchoredPosition.x - miniMapPoint_2.anchoredPosition.x), 2) +
                Mathf.Pow((miniMapPoint_1.anchoredPosition.y - miniMapPoint_2.anchoredPosition.y), 2));
            miniMapRatio = distanceMiniMap / distanceWorld;
        }

        public void VisitRoom(Vector2Int pos)
        {
            cells[pos.x, pos.y].SetVisited();
        }
        public void PlayerInHere(Vector2Int pos)
        {
            cells[pos.x, pos.y].SetPlayerHere();
        }

        public void SetBossRoom(Vector2Int pos)
        {
            cells[pos.x, pos.y].SetBossRoom();
        }

        public void UpdatePlayerPosition(Vector2Int newPos)
        {
            if (IsInBounds(playerPos))
                VisitRoom(playerPos);

            playerPos = newPos;

            if (IsInBounds(playerPos))
                cells[playerPos.x, playerPos.y].SetPlayerHere();
        }

        private bool IsInBounds(Vector2Int pos)
        {
            return pos.x >= 0 && pos.y >= 0 && pos.x < width && pos.y < height;
        }
    } 
}
