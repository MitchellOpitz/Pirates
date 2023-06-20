using UnityEngine;

public class TerrainGround : MonoBehaviour
{
    public int gridSizeX = 10;
    public int gridSizeY = 10;
    public GameObject terrainParent;
    public GameObject waterTilePrefab;
    public GameObject grassTilePrefab;
    public GameObject sandTilePrefab;

    private GameObject[,] terrainGrid;

    public void Generate()
    {
        terrainGrid = new GameObject[gridSizeX, gridSizeY];
        GameObject terrainParentObj = new GameObject("Ground");
        terrainParentObj.transform.parent = terrainParent.transform;
        terrainParentObj.transform.position = new Vector3(0, 0, -1);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // Generate tile types randomly or based on specific rules
                GameObject tilePrefab = GetRandomTilePrefab();

                // Instantiate the tile prefab at the corresponding grid position
                Vector3 position = new Vector3(x, y, 0);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.transform.parent = terrainParentObj.transform;
                terrainGrid[x, y] = tile;
            }
        }
    }

    private GameObject GetRandomTilePrefab()
    {
        // Add logic to randomly select and return a tile prefab
        // You can adjust the probabilities or use specific rules for different tile types
        GameObject[] tilePrefabs = { waterTilePrefab, grassTilePrefab, sandTilePrefab };
        return tilePrefabs[Random.Range(0, tilePrefabs.Length)];
    }
}
