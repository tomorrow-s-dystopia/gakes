using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private HealthSystem playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = playerHealth.hp <= 0;
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
