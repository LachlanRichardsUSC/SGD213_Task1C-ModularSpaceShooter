using UnityEngine;

/// <summary>
/// Spawns an object repeatedly over time at a random position within the bounds of the attached renderer.
/// </summary>
public class SpawnOverTimeScript : MonoBehaviour
{
    // Prefab to spawn
    [SerializeField]
    private GameObject spawnObject;  

    // Delay between each spawn
    [SerializeField]
    private float spawnDelay = 2f;  

    // Renderer used to determine the bounds for spawning
    private Renderer ourRenderer;  

    /// <summary>
    /// Initializes the spawner by hiding its renderer and setting up repeated spawning.
    /// </summary>
    void Start()
    {
        ourRenderer = GetComponent<Renderer>();
        if (ourRenderer != null)
        {
            // Hide the spawner's renderer to make it invisible
            ourRenderer.enabled = false;

            // Start the repeated spawning process
            InvokeRepeating("Spawn", spawnDelay, spawnDelay);
        }
        else
        {
            Debug.LogError("Renderer component not found, spawner will not function correctly.");
        }
    }

    /// <summary>
    /// Spawns an object at a random horizontal position within the bounds of the renderer.
    /// </summary>
    void Spawn()
    {
        if (ourRenderer != null)
        {
            float x1 = transform.position.x - ourRenderer.bounds.size.x / 2;
            float x2 = transform.position.x + ourRenderer.bounds.size.x / 2;

            // Randomly pick a point within the bounds of the renderer to spawn the object
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

            // Instantiate the object at the calculated spawn point
            Instantiate(spawnObject, spawnPoint, Quaternion.identity);
        }
    }
}
