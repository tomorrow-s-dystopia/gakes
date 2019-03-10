using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeRange : MonoBehaviour
{

    private MeleeTargets meleeTargets;
    // Start is called before the first frame update
    void Start()
    {
        var player = transform.parent.gameObject;
        meleeTargets = player.GetComponent<MeleeTargets>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("player OnTriggerEnter2D");
        if(otherCollider.tag != "Enemy") return;
        
        meleeTargets.addTarget(otherCollider);

    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("player OnTriggerExit2D");
        if(otherCollider.tag != "Enemy") return;
       
        meleeTargets.removeTarget(otherCollider);
    }
}
