using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    public bool isPlayerDead;
    void Start()
    {
        isDead = false;
        isAttacking = false;
        isMoving = false;
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
