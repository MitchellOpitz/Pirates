using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Constrain the player's movement within the playable area
        newPosition.x = Mathf.Clamp(newPosition.x, PlayableArea.Instance.minX, PlayableArea.Instance.maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, PlayableArea.Instance.minY, PlayableArea.Instance.maxY);

        transform.position = newPosition;
    }
}
