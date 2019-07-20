using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    private MeleeTargets meleeTargets;
    private HealthSystem health;
    private PlayerStatus status;

    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        meleeTargets = GetComponent<MeleeTargets>();
        health = GetComponent<HealthSystem>();
        status = GetComponent<PlayerStatus>();
        hitSound = GetComponent<AudioSource>();
    }

    void MeleeAttack()
    {
        List<HealthSystem> targets = meleeTargets.Targets;
        bool isHit = false;
        foreach (HealthSystem target in targets)
        {
            target.DecreaseHealth(13);
            isHit = true;
        }
        if(isHit)
            hitSound.Play();
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
