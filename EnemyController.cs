using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 3; // Total health of the enemy
    private int currentHealth; // Current health of the enemy

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any behavior for the enemy here
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by damage amount

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health is 0 or less
        }
    }

    // Method to handle enemy death
    private void Die()
    {
        // Add any death animation or effects here

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
