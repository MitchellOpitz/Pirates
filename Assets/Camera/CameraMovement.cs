using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset; // Offset between the camera and the player

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Get the boundaries from the PlayableArea script
        float minX = PlayableArea.Instance.minX;
        float maxX = PlayableArea.Instance.maxX;
        float minY = PlayableArea.Instance.minY;
        float maxY = PlayableArea.Instance.maxY;

        // Clamp the camera's position to stay within the playable area boundaries
        float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minY, maxY);
        smoothedPosition = new Vector3(clampedX, clampedY, -10f); // Set Z position to -10

        transform.position = smoothedPosition;
    }
}
