using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSystem : DamageSystem
{
    private EnemyStatus status;

    private int reduceDamage = 0;

    void Start()
    {
        status = GetComponent<EnemyStatus>();
    }
    public override int CalculateDamage(int damage)
    {
        return Mathf.Max(damage - reduceDamage, 0);
    }
}
