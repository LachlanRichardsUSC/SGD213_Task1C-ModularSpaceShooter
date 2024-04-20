using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines how to interact with any health component.
/// </summary>
public interface IHealth
{
    // Property to get the current amount of health.
    int CurrentHealth { get; }

    // Property to get the maximum health.
    int MaxHealth { get; }

    /// <summary>
    /// Take damage with the specified amount.
    /// </summary>
    /// <param name="damageAmount">The amount of damage to apply.</param>
    void TakeDamage(int damageAmount);

    /// <summary>
    /// Heal with the specified amount.
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain.</param>
    void Heal(int healingAmount);

    /// <summary>
    /// Determine if the object can receive health from pickups.
    /// </summary>
    /// <returns>True if the object can receive health, otherwise false.</returns>
    bool CanReceiveHealth();

    /// <summary>
    /// Handle the behavior when health reaches zero.
    /// </summary>
    void Die();
}
