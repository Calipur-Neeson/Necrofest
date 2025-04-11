using UnityEngine;

public class CreatHill : MonoBehaviour
{
    public Terrain terrain; // 需要修改的地形
    public float mountainHeight = 0.2f; // 小山的最大高度
    public float mountainRadius = 10f; // 小山的半径
    public Vector3 mountainCenter; // 小山的中心点位置

    void Start()
    {
        if (terrain == null) terrain = Terrain.activeTerrain;
        CreateMountain();
    }

    void CreateMountain()
    {
        TerrainData terrainData = terrain.terrainData;
        int heightmapWidth = terrainData.heightmapResolution;
        int heightmapHeight = terrainData.heightmapResolution;

        // 获取当前高度图
        float[,] heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);

        // 计算地形中心相对位置
        Vector3 terrainPos = terrain.transform.position;
        int centerX = Mathf.RoundToInt((mountainCenter.x - terrainPos.x) / terrainData.size.x * heightmapWidth);
        int centerY = Mathf.RoundToInt((mountainCenter.z - terrainPos.z) / terrainData.size.z * heightmapHeight);

        // 创建小山：在一个半径范围内抬高地形
        for (int x = centerX - Mathf.RoundToInt(mountainRadius); x < centerX + Mathf.RoundToInt(mountainRadius); x++)
        {
            for (int y = centerY - Mathf.RoundToInt(mountainRadius); y < centerY + Mathf.RoundToInt(mountainRadius); y++)
            {
                if (x >= 0 && x < heightmapWidth && y >= 0 && y < heightmapHeight)
                {
                    // 计算该点距离小山中心的距离
                    float distance = Vector2.Distance(new Vector2(x, y), new Vector2(centerX, centerY));

                    // 如果该点在山的半径内，抬高它
                    if (distance <= mountainRadius)
                    {
                        // 使用一个衰减函数来控制山的形状，形成小山的效果
                        float heightFactor = 1f - (distance / mountainRadius); // 距离越远，抬高越低
                        heights[x, y] += mountainHeight * heightFactor; // 抬高当前点
                    }
                }
            }
        }
    }
}
