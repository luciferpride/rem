using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 4f;
    [SerializeField]
    float runSpeed = 8f;

    Vector3 forward, right;
    Animator animator;

    bool isrunning = false;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        CheckRunning();
        CheckAttack();
    }

    void Move()
    {
        float currentSpeed = isrunning ? runSpeed : walkSpeed;
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * currentSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * currentSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        // Play walking or running animation
        if (direction != Vector3.zero)
        {
            if (isrunning)
            {
                PlayAnimation("Running");
            }
            else
            {
                PlayAnimation("Walking");
            }
        }
        else
        {
            PlayAnimation("Idle");
        }
    }

    void CheckRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isrunning = true;
        }
        else
        {
            isrunning = false;
        }
    }

    void CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayAnimation("Attack1");
        }
    }

    string currentAnimation;
    void PlayAnimation(string animationName)
    {
        if (animationName == currentAnimation) { return; }
        animator.Play(animationName);
        currentAnimation = animationName;
    }
}