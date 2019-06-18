using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPosition : MonoBehaviour
{
    private Collider2D attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<Collider2D>();
    }

    public void flip(){
        attackCollider.offset = new Vector2(-attackCollider.offset.x, attackCollider.offset.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
