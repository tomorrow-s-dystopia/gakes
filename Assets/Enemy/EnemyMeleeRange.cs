using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeRange : MonoBehaviour
{
    private MeleeTargets meleeTargets;
    // Start is called before the first frame update
    void Start()
    {
        meleeTargets = GetComponentInParent<MeleeTargets>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //   Debug.Log("player OnTriggerEnter2D");
        if (otherCollider.tag != "Enemy") return;

        meleeTargets.AddTarget(otherCollider);

    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        //    Debug.Log("player OnTriggerExit2D");
        if (otherCollider.tag != "Enemy") return;

        meleeTargets.RemoveTarget(otherCollider);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
