using UnityEngine;

public class GraveSingleRoom : MonoBehaviour
{
    public TerrainLayer[] terrainLayers;
    public GameObject[] objectsToSpawn;
    [SerializeField] private int objectCount;


    private Terrain terrain;
    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        RandomizeTexture();
        RandomizeObjects();
    }
    private void OnEnable()
    {
        RandomizeTexture();
        RandomizeObjects();
    }


    void RandomizeTexture()
    {
        TerrainLayer[] selectedLayers = new TerrainLayer[terrainLayers.Length];
        for (int i = 0; i < selectedLayers.Length; i++)
        {
            selectedLayers[i] = terrainLayers[Random.Range(0, terrainLayers.Length)];
        }
        terrain.terrainData.terrainLayers[0] = selectedLayers[0];
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
