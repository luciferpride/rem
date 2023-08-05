using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public Image healthbar;
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
        healthbar.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // Add any death behavior or game over logic here
        Debug.Log("Player is dead!");
        isDead = true;
    }

    public void Heal(int healAmount)
    {
        if (isDead)
            return;

        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
