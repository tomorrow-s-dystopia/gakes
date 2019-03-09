using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = GetComponent<PlayerHealth>().hp <= 0;
        if(isDead){
            return;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            spriteRenderer.flipX = true;
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            spriteRenderer.flipX = false;
        }
    }
}
