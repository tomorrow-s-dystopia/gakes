using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private EnemyStatus status;
    private EnemyAttackSystem enemyAttack;

    private EnemyMovement enemyMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
        enemyAttack = GetComponent<EnemyAttackSystem>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void FixedUpdate()
    {
        float horizontalMovement = Mathf.Abs(enemyMovement.MoveHorziontal);
        float verticalMovement = Mathf.Abs(enemyMovement.MoveVertical);
        animator.SetFloat("speed", Mathf.Max(horizontalMovement, verticalMovement));
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_dying"))
        {
            animator.SetBool("isDead", true);
        }

        if (status.isDead) return;

        if (status.isDying)
        {
            Debug.Log("enemy died");
            animator.ResetTrigger("attack");
            animator.SetTrigger("die");
            status.onDeath();
            return;
        }

        if (status.isAttacking)
        {
            animator.SetTrigger("attack");
        }
    }
}
