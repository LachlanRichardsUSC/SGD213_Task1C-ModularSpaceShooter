using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IHealth healthComponent = other.GetComponent<IHealth>();
        if (healthComponent != null && healthComponent.CanReceiveHealth())
        {
            healthComponent.Heal(healthAmount);
            Destroy(gameObject);  // Destroy the health pickup after it is used.
        }
    }
}
