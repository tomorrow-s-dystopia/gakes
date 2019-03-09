using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var healthBar = this.gameObject.transform.GetChild(1);
        playerHealth = healthBar.GetComponent<PlayerHealth>();
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
