using UnityEngine;

/// <summary>
/// Applies damage to objects that have an IHealth component upon collision.
/// This script inherits from DetectCollisionBase and extends its functionality to include damage processing.
/// </summary>
public class DamageOnCollision : DetectCollisionBase
{
    [SerializeField]
    private int damageToDeal; // The amount of damage to deal to the collided object.

    /// <summary>
    /// Processes collisions with other GameObjects to apply damage if they implement IHealth.
    /// Automatically destroys the GameObject this script is attached to after processing the collision.
    /// </summary>
    /// <param name="other">The GameObject this object collided with.</param>
    protected override void ProcessCollision(GameObject other)
    {
        base.ProcessCollision(other); // Calls the base class method to handle any base functionality.

        IHealth healthComponent = other.GetComponent<IHealth>();
        if (healthComponent != null)
        {
            // Apply damage to the object if it has an IHealth component.
            healthComponent.TakeDamage(damageToDeal);
        }
        else
        {
            // Log a message if the other object does not have an IHealth component.
            Debug.LogWarning($"{other.name} does not have an IHealth component.");
        }

        
        Destroy(gameObject);
    }
}
