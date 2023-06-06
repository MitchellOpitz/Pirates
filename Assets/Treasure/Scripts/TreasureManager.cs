using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public GameObject treasurePrefab; // Prefab of the treasure object
    public Transform treasureParent; // Parent transform for organizing treasures
    public bool generateOnStart = true; // Whether to generate treasure on start

    private Vector3 treasurePosition; // Position of the treasure

    private void Start()
    {
        if (generateOnStart)
        {
            GenerateTreasure();
        }
    }

    public void GenerateTreasure()
    {
        // Generate a random position within the playable area
        float randomX = Random.Range(PlayableArea.Instance.minX, PlayableArea.Instance.maxX);
        float randomY = Random.Range(PlayableArea.Instance.minY, PlayableArea.Instance.maxY);
        treasurePosition = new Vector3(randomX, randomY, 0f);

        // Instantiate the treasure object at the generated position
        GameObject newTreasure = Instantiate(treasurePrefab, treasurePosition, Quaternion.identity);
        newTreasure.transform.parent = treasureParent;
    }

    public void BuryNewTreasure()
    {
        // Destroy any existing treasure
        DestroyExistingTreasure();

        // Generate a new treasure
        GenerateTreasure();
    }

    private void DestroyExistingTreasure()
    {
        // Destroy any existing treasure object in the scene
        foreach (Transform child in treasureParent)
        {
            Destroy(child.gameObject);
        }
    }
}
