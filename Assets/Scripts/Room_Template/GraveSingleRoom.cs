using UnityEngine;

public class GraveSingleRoom : MonoBehaviour
{
    public TerrainLayer[] terrainLayers;
    public GameObject[] objectsToSpawn;
    [SerializeField] private int objectCount;


    private Terrain terrain;
    private void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateHill();
        RandomizeTexture();
        RandomizeObjects();
    }
    private void OnEnable()
    {
        GenerateHill();
        RandomizeTexture();
        RandomizeObjects();
    }

    void GenerateHill()
    {
        int width = terrain.terrainData.heightmapResolution;
        int height = terrain.terrainData.heightmapResolution;
        Debug.Log(width);

        float[,] heights = terrain.terrainData.GetHeights(0, 0, width, height);
        int hillX = Random.Range(50, width - 50); 
        int hillY = Random.Range(50, height - 50);
        int hillSize = Random.Range(20, 50); 
        float hillHeight = Random.Range(1f, 5f);
        for (int x = -hillSize; x < hillSize; x++)
        {
            for (int y = -hillSize; y < hillSize; y++)
            {
                int px = hillX + x;
                int py = hillY + y;

                if (px >= 0 && px < width && py >= 0 && py < height)
                {
                    float distance = Mathf.Sqrt(x * x + y * y) / hillSize;
                    float strength = Mathf.Clamp01(1 - distance); 
                    float noise = Mathf.PerlinNoise(px * 0.1f, py * 0.1f) * strength; 

                    heights[px, py] += noise * hillHeight; 
                }
            }
        }

        terrain.terrainData.SetHeights(0, 0, heights);
    }

    void RandomizeTexture()
    {
        TerrainLayer[] selectedLayers = new TerrainLayer[terrainLayers.Length];
        for (int i = 0; i < selectedLayers.Length; i++)
        {
            selectedLayers[i] = terrainLayers[Random.Range(0, terrainLayers.Length)];
        }
        terrain.terrainData.terrainLayers = selectedLayers;
    }
    void RandomizeObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            float x = Random.Range(0, terrain.terrainData.size.x);
            float z = Random.Range(0, terrain.terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z));

            Vector3 position = terrain.transform.position + new Vector3(x, y, z);
            Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], position, Quaternion.identity, transform);
        }
    }
}
