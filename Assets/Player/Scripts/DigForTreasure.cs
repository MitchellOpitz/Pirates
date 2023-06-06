using UnityEngine;

public class DigForTreasure : MonoBehaviour
{
    private void Update()
    {
        // Check for the player's input to initiate digging
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject treasureObject = CheckForTreasure();
            if (treasureObject != null)
            {
                Dig(treasureObject);
            }
            else
            {
                Debug.Log("Treasure not found");
            }
        }
    }

    private GameObject CheckForTreasure()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Treasure"))
            {
                return collider.gameObject;
            }
        }
        return null;
    }

    private void Dig(GameObject treasureObject)
    {
        // Implement the logic for digging or obtaining the treasure here
        // You can play a particle effect, show a message, increment score, etc.
        Debug.Log("Treasure found!");

        // Destroy the treasure object
        Destroy(treasureObject);
    }
}
