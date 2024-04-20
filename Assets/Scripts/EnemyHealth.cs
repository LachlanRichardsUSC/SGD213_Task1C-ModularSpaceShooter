using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary cleanup.
    /// </summary>
    public void Die()
    {
        // would be good to do some death animation here maybe
        // remove this object from the game
        Destroy(gameObject);
    }
}
