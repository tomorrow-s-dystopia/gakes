using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStatus status;
    private GameObject target;

    void Start()
    {
        status = GetComponent<EnemyStatus>();
        target = GameObject.Find("Player");
    }

    bool CanAttack()
    {
        MeleeTargets meleeTargets = GetComponent<MeleeTargets>();
        return meleeTargets.Targets.Count > 0;
    }

    void Update()
    {
        if (status.isDead || status.isDying) return;

        status.isAttacking = CanAttack();
    }
}
