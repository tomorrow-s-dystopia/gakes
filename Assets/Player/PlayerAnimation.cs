using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private HealthSystem playerHealth;
    private PlayerMovement playerMovement;
    private PlayerStatus status;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<HealthSystem>();
        playerMovement = GetComponent<PlayerMovement>();
        status = GetComponent<PlayerStatus>();
    }

    float PlayerMovementAnimationSpeed()
    {
        float horizontalMovement = Mathf.Abs(playerMovement.MoveHorziontal);
        float verticalMovement = Mathf.Abs(playerMovement.MoveVertical);
        return Mathf.Max(horizontalMovement, verticalMovement);
    }

    void FixedUpdate()
    {
        animator.SetFloat("speed", PlayerMovementAnimationSpeed());
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_dying"))
        {
            animator.SetBool("isDead", true);
        }

        if (status.isDead) return;

        if (status.isDying)
        {
            Debug.Log("player died");
            animator.ResetTrigger("attack");
            animator.SetTrigger("die");
            status.onDeath();
            return;
        }

        if (status.isAttacking)
        {
            animator.SetTrigger("attack");
        }

        if (!status.isAttacking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("isBlocking", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isBlocking", false);
        }
    }
}
