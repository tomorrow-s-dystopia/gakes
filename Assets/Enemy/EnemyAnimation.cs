using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private HealthSystem enemyHealth;
        private EnemyStatus enemyStatus;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<HealthSystem>();
        enemyStatus = GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("dead");
        if(enemyHealth.hp <= 0 && !enemyStatus.isDead){
            animator.SetTrigger("dead");
            enemyStatus.isDead = true;
        }
    }
}
