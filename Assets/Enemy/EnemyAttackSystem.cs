using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    public PlayerAttackSystem playerInRange { get; set; }
    private EnemyAnimation animator;
    private EnemyStatus status;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<EnemyAnimation>();
        status = GetComponent<EnemyStatus>();
        playerInRange = null;
    }

    public bool MeleeAttack()
    {
        return playerInRange.Defend(13);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
