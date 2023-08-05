using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // Add any death behavior or enemy destruction logic here
        // For example, you can play a death animation or particle effect, and then destroy the enemy GameObject
        Debug.Log("Enemy is dead!");
        isDead = true;
        Destroy(gameObject);
    }
}
