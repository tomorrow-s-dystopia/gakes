using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    void Start()
    {
        isDead = false;
        isAttacking = false;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
