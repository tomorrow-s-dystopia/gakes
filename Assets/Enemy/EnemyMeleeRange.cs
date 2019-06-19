using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeRange : MonoBehaviour
{
    private MeleeTargets meleeTargets;

    void Start()
    {
        meleeTargets = GetComponentInParent<MeleeTargets>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag != "Player") return;

        meleeTargets.AddTarget(otherCollider);

    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag != "Player") return;

        meleeTargets.RemoveTarget(otherCollider);
    }
}
