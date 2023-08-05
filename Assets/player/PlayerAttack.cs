using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint; // The point from where the attack originates (usually an empty GameObject child of the player)
    public float attackRange = 1f; // The range of the attack
    public LayerMask enemyLayer; // Layer mask for detecting enemies

    public float attackCooldown = 0.5f; // Cooldown between attacks
    private bool canAttack = true;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Play the attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in the attack range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        // Damage the enemies
        foreach (Collider enemy in hitEnemies)
        {
            // Here, you can implement your enemy damage script to deal damage to the enemy
            // For example, if the enemy has a script called EnemyHealth, you can call enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }

        // Set a cooldown before the player can attack again
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}

