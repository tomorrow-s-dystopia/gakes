using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Collider2D playerCollision;

    private HealthSystem playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<HealthSystem>();
        playerCollision = GetComponent<Collider2D>();
    }

    private void flip(){
        if(spriteRenderer.flipX) return;

        spriteRenderer.flipX = true;
        playerCollision.offset = new Vector2(-playerCollision.offset.x,playerCollision.offset.y);
    }

    private void unflip(){
        if(!spriteRenderer.flipX) return;

        spriteRenderer.flipX = false;
        playerCollision.offset = new Vector2(-playerCollision.offset.x,playerCollision.offset.y);
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = playerHealth.currentHp <= 0;
        if(isDead){
            return;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            flip();
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            unflip();
        }
    }
}
