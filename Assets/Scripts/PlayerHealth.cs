using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages health for the player, including taking damage and healing.
/// </summary>
public class PlayerHealth : MonoBehaviour, IHealth
{
    

    [SerializeField]
    private int currentHealth;

    /// <summary>
    /// Gets the current health of the player.
    /// </summary>
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    private int maxHealth;

    /// <summary>
    /// Gets the maximum health of the player.
    /// </summary>
    public int MaxHealth { get { return maxHealth; } }

    /// <summary>
    /// Event that is triggered whenever the health percentage changes.
    /// This is useful for UI updates or other reactions to health changes.
    /// </summary>
    public UnityEvent<float> onHealthPercentageChanged;

    /// <summary>
    /// Sets initial health and updates UI on start.
    /// </summary>
    void Awake()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Post-initialization updates, like refreshing the UI to reflect the initial health state.
    /// </summary>
    void Start()
    {
        UpdateHealthUI();
    }

    /// <summary>
    /// Increases the player's health by a specified amount.
    /// Does not allow overhealing past the maximum health.
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain, expected to be positive.</param>
    public void Heal(int healingAmount)
    {
        if (healingAmount < 0)
        {
            Debug.LogWarning("Attempt to heal with a negative value.");
            return;
        }
        currentHealth += healingAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthUI();
    }
    /// <summary>
    /// Boolean statement whether this object can receive healing.
    /// </summary>
    public bool CanReceiveHealth()
    {
        return true;
    }

    /// <summary>
    /// Reduces the player's health by a specified damage amount.
    /// Triggers death if health falls to zero or below.
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
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Updates the health UI. Invokes the onHealthPercentageChanged event with the current health percentage.
    /// </summary>
    private void UpdateHealthUI()
    {
        float healthPercentage = (float)currentHealth / (float)maxHealth;
        onHealthPercentageChanged.Invoke(healthPercentage);
    }

    /// <summary>
    /// Handles the player's death, such as playing animations, notifying other systems and destroying the player object.
    /// </summary>
    public void Die()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject);
    }
}
