using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    /// <summary>
    /// Obtainable item in game that gives the player 25 health points.
    /// Checks whether the object it collides with can receive health with
    /// a simple boolean check rather than relying on Tags.
    /// </summary>
    public int healthAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IHealth healthComponent = other.GetComponent<IHealth>();
        if (healthComponent != null && healthComponent.CanReceiveHealth())
        {
            healthComponent.Heal(healthAmount);
            Destroy(gameObject);
        }
    }
}
