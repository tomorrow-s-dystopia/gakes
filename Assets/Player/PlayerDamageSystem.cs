using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSystem : DamageSystem
{
    private PlayerStatus status;

    private int reduceDamage = 0;
    void Start()
    {
        status = GetComponent<PlayerStatus>();
    }
    public override int CalculateDamage(int damage)
    {
        return Mathf.Max(damage - reduceDamage, 0);
    }

    void Update()
    {
        reduceDamage = status.isBlocking ? 10 : 0;
    }
}
