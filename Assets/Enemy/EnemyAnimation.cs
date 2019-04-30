using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private HealthSystem enemyHealth;
    private EnemyStatus enemyStatus;
    private EnemyAttackSystem enemyAttack;
    public bool isAttacking { get; set; }
    private System.Timers.Timer attackTimer;
    private bool attackInCooldown;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<HealthSystem>();
        enemyStatus = GetComponent<EnemyStatus>();
        enemyAttack = GetComponent<EnemyAttackSystem>();
        isAttacking = false;
        attackTimer = new System.Timers.Timer(1000);
        attackTimer.Elapsed += ResetAttack;
        attackTimer.AutoReset = true;
        attackTimer.Enabled = false;
        attackInCooldown = false;
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("enemy OnTriggerEnter2D");
        if (otherCollider.tag != "Player") return;

        enemyAttack.playerInRange = otherCollider.GetComponent<PlayerAttackSystem>();
        isAttacking = true;
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("enemy OnTriggerExit2D");
        if (otherCollider.tag != "Player") return;

        enemyAttack.playerInRange = null;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", isAttacking && !attackInCooldown);

        if (enemyHealth.Hp <= 0 && !enemyStatus.isDead)
        {
            Debug.Log("enemy is dead");
            animator.SetTrigger("dead");
            enemyStatus.isDead = true;
            isAttacking = false;
            return;
        }

        if(!enemyStatus.isDead)
            animator.ResetTrigger("dead");

        if (isAttacking && !enemyStatus.isDead)
        {
            attackTimer.Enabled = true;
            if (!attackInCooldown)
            {
                isAttacking = enemyAttack.MeleeAttack();
                attackInCooldown = true;
            }
        }
        else
        {
            attackTimer.Enabled = false;
        }
    }

    private void ResetAttack(object source, System.Timers.ElapsedEventArgs e)
    {
        attackInCooldown = false;
    }
}
