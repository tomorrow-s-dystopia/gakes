using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private BodyPosition playerBodyPosition;

    private AttackPosition attackPosition;

    private HealthSystem playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<HealthSystem>();
        playerBodyPosition = GetComponentInChildren<BodyPosition>();
        attackPosition = GetComponentInChildren<AttackPosition>();
    }

    private void flip(){
        spriteRenderer.flipX = !spriteRenderer.flipX;
        playerBodyPosition.flip();
        attackPosition.flip();
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = playerHealth.currentHp <= 0;
        if(isDead){
            return;
        }
        bool turningLeft = Input.GetKeyDown(KeyCode.A) && !spriteRenderer.flipX;
        bool turningRight = Input.GetKeyDown(KeyCode.D)  && spriteRenderer.flipX;
        if(turningLeft || turningRight){
            flip();
        }
    }
}
