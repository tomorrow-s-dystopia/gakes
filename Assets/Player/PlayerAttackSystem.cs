using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    private MeleeTargets meleeTargets;
    private HealthSystem health;
    private PlayerStatus status;
    // Start is called before the first frame update
    void Start()
    {
        meleeTargets = GetComponent<MeleeTargets>();
        health = GetComponent<HealthSystem>();
        status = GetComponent<PlayerStatus>();
    }

    void MeleeAttack()
    {
        List<HealthSystem> targets = meleeTargets.Targets;
        foreach (HealthSystem target in targets)
        {
            target.DecreaseHealth(13);
        }
    }

    void Update()
    {
        bool isBusy = status.isDying || status.isDead || status.isBlocking;
        if (isBusy) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MeleeAttack();
        }
    }
}
