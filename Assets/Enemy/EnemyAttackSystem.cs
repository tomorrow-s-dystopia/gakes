using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    public PlayerAttackSystem playerInRange { get; set; }
    private EnemyAnimation animator;
    private EnemyStatus status;
    private System.Timers.Timer attackTimer;
    private bool attackInCooldown;
    private MeleeTargets meleeTargets;

    void Start()
    {
        animator = GetComponent<EnemyAnimation>();
        meleeTargets = GetComponent<MeleeTargets>();
        status = GetComponent<EnemyStatus>();

        attackTimer = new System.Timers.Timer(1000);
        attackTimer.Elapsed += ResetAttack;
        attackTimer.AutoReset = true;
        attackTimer.Enabled = false;
        attackInCooldown = false;
    }

    private void ResetAttack(object source, System.Timers.ElapsedEventArgs e)
    {
        attackInCooldown = false;
    }

    public void MeleeAttack()
    {
        List<HealthSystem> targets = meleeTargets.Targets;
        foreach (HealthSystem target in targets)
        {
            target.DecreaseHealth(13);
        }
    }

    void Update()
    {
        if (!status.isAttacking) {
            attackTimer.Enabled = false;
            attackInCooldown = false;
            return;
        };

        if (!attackInCooldown)
        {
            attackInCooldown = true;
            attackTimer.Enabled = true;
            MeleeAttack();
        }
    }
}
