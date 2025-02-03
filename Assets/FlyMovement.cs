using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
    public Transform mountain; // The mountain object to orbit
    public float radius = 20f; // Radius of the orbit
    public float heightVariation = 5f; // Vertical oscillation height
    public float speed = 2f; // Orbit speed
    public float heightOffset = 10f; // Vertical offset from the mountain
    public Vector3 terrainCenter; // Center of the terrain
    public Vector2 terrainSize = new Vector2(100, 100); // Terrain size (width and depth)

    private float angle = 0f; // Tracks the current angle for circular motion

    void Update()
    {
        // Update the angle based on speed and time
        angle += speed * Time.deltaTime;

        // Calculate the horizontal position (circular orbit around the mountain)
        float x = mountain.position.x + Mathf.Cos(angle) * radius;
        float z = mountain.position.z + Mathf.Sin(angle) * radius;

        // Clamp the position within the terrain bounds
        x = Mathf.Clamp(x, terrainCenter.x - terrainSize.x / 2, terrainCenter.x + terrainSize.x / 2);
        z = Mathf.Clamp(z, terrainCenter.z - terrainSize.y / 2, terrainCenter.z + terrainSize.y / 2);

        // Calculate vertical oscillation with a height offset
        float y = mountain.position.y + heightOffset + Mathf.Sin(angle * 0.5f) * heightVariation;

        // Update the object's position
        transform.position = new Vector3(x, y, z);
    }
}
