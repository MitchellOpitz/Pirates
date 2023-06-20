using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public TerrainGround terrainGround;
    //public TerrainObjects terrainObjects;

    private void Start()
    {
        GenerateNewTerrain();
    }

    public void GenerateNewTerrain()
    {
        terrainGround.Generate();
        //terrainObjects.Generate();
    }
}
