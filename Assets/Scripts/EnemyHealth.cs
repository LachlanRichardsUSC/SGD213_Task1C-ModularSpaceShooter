using UnityEngine;

/// <summary>
/// Manages the health of enemy units in the game, including healing and taking damage.
/// </summary>
public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int currentHealth;

    /// <summary>
    /// Gets the current health of the enemy.
    /// </summary>
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    private int maxHealth; 

    /// <summary>
    /// Gets the maximum health of the enemy.
    /// </summary>
    public int MaxHealth { get { return maxHealth; } }

    /// <summary>
    /// Initializes the enemy's health at the start of the game.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Increases the enemy's health by a specified amount, not exceeding the maximum health.
    /// </summary>
    /// <param name="healingAmount">The amount of health to add, expected to be positive.</param>
    public void Heal(int healingAmount)
    {
        // No operation (no-op) if enemies don't need to heal.
        // Log a message if needed for debugging.
        Debug.LogWarning("Attempted to heal an enemy, which should not happen.");
    }

    /// <summary>
    /// Determines whether the enemy can receive health from pickups. Always returns false for enemies.
    /// </summary>
    /// <returns>False, as enemies should not receive health from pickups.</returns>
    public bool CanReceiveHealth()
    {
        return false;
    }

    /// <summary>
    /// Reduces the enemy's health by a specified damage amount and handles death if health reaches zero.
    /// </summary>
    /// <param name="damageAmount">The amount of damage to take, expected to be positive.</param>
    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0)
        {
            Debug.LogWarning("Attempt to take damage with a negative value.");
            return;
        }
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Performs cleanup when the enemy's health reaches zero, such as playing death animations and removing the enemy from the game.
    /// </summary>
    public void Die()
    {
        Debug.Log($"Enemy at {transform.position} has died.");
        Destroy(gameObject);
    }
}
