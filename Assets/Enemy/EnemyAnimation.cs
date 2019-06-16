using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private HealthSystem enemyHealth;
    private EnemyStatus enemyStatus;
    private EnemyAttackSystem enemyAttack;

    private EnemyMovement enemyMovement;

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
        enemyMovement = GetComponent<EnemyMovement>();
        isAttacking = false;
        attackTimer = new System.Timers.Timer(1000);
        attackTimer.Elapsed += ResetAttack;
        attackTimer.AutoReset = true;
        attackTimer.Enabled = false;
        attackInCooldown = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("enemy OnCollisionExit2D");
        Collider2D collider = collision.collider;
        if (collider.tag != "Player") return;

        enemyAttack.playerInRange = collider.GetComponent<PlayerAttackSystem>();
        isAttacking = true;
        enemyMovement.isMoving = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
     //   Debug.Log("enemy OnCollisionExit2D");
        Collider2D collider = collision.collider;
        if (collider.tag != "Player") return;

        enemyAttack.playerInRange = null;
        isAttacking = false;
        enemyMovement.isMoving = true;
    }

    void FixedUpdate(){
        float horizontalMovement = Mathf.Abs(enemyMovement.MoveHorziontal);
        float verticalMovement = Mathf.Abs(enemyMovement.MoveVertical);
        animator.SetFloat("speed", Mathf.Max(horizontalMovement, verticalMovement));
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", isAttacking && !attackInCooldown);

        if (enemyHealth.currentHp <= 0 && !enemyStatus.isDead)
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
