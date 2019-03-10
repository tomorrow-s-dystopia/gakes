using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeRange : MonoBehaviour
{

    private Collider2D meleeAttackCollider;
    // Start is called before the first frame update
    void Start()
    {
        meleeAttackCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag != "Enemy") return;

        Debug.Log("player OnTriggerEnter2D");
        Debug.Log(name);
        Debug.Log(otherCollider.name);
    }
}
