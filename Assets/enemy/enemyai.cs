using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    public Transform target; // Reference to the player's Transform
    public float followRange = 10f; // Range within which the enemy will start following the player
    public float attackRange = 2f; // Range within which the enemy will start attacking the player
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the player
    public int damageAmount = 10; // Amount of damage the enemy deals to the player
    public float attackCooldown = 2f; // Cooldown between consecutive attacks

    private Animator animator;
    private bool isFollowing = false;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            if (distanceToPlayer <= followRange)
            {
                isFollowing = true;
            }
            else
            {
                isFollowing = false;
                isAttacking = false;
                StopMoving();
            }

            if (isFollowing)
            {
                if (distanceToPlayer <= attackRange && !isAttacking)
                {
                    StopMoving();
                    StartCoroutine(Attack());
                }
                else
                {
                    MoveTowardsPlayer();
                }
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        transform.forward = direction.normalized;

        animator.SetBool("IsRunning", true);
        animator.SetBool("IsAttacking", false);

        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }

    void StopMoving()
    {
        animator.SetBool("IsRunning", false);
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        animator.SetBool("IsRunning", false);
        animator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(attackCooldown);

        if (target != null && Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            // Deal damage to the player (You can have your own player health script)
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }

        animator.SetBool("IsAttacking", false);
        isAttacking = false;
    }
}
