using UnityEngine;

public class PlayableArea : MonoBehaviour
{
    public static PlayableArea Instance; // Singleton instance

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
