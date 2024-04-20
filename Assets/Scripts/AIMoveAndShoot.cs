using UnityEngine;

/// <summary>
/// Controls AI movement and shooting behaviors for an enemy object.
/// This script should be attached to any enemy GameObject that requires automated movement and shooting capabilities.
/// </summary>
public class AIMoveAndShoot : MonoBehaviour
{
    // Stores the current movement direction of the AI.
    private Vector2 movementDirection;

    // Reference to the EngineBase component for handling movement.
    private EngineBase enemyMovement;

    // Reference to the WeaponBase component for handling shooting.
    private WeaponBase weapon;

    /// <summary>
    /// Initializes component references and sets the initial movement direction.
    /// </summary>
    void Start()
    {
        enemyMovement = GetComponent<EngineBase>();
        if (enemyMovement == null)
            Debug.LogWarning("EngineBase not found on " + gameObject.name);

        weapon = GetComponent<WeaponBase>();
        if (weapon == null)
            Debug.LogWarning("WeaponBase not found on " + gameObject.name);

        InitializeMovementDirection();
    }

    /// <summary>
    /// Handles physics-based movement updates. It is called every fixed framerate frame.
    /// </summary>
    void FixedUpdate()
    {
        if (enemyMovement != null)
        {
            enemyMovement.Accelerate(movementDirection);
        }
    }

    /// <summary>
    /// Handles weapon shooting updates. It is called once per frame.
    /// </summary>
    void Update()
    {
        if (weapon != null)
        {
            weapon.Shoot();
        }
    }

    /// <summary>
    /// Sets a random horizontal (X-axis) direction combined with a downward (negative Y-axis) component,
    /// then normalizes the vector to ensure consistent movement speed.
    /// </summary>
    private void InitializeMovementDirection()
    {
        float x = Random.Range(-0.5f, 0.5f); 
        float y = -0.5f;
        // Normalize to maintain consistent speed.
        movementDirection = new Vector2(x, y).normalized;
    }
}
