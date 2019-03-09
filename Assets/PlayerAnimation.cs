using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    private PlayerStatus playerStatus;
    void Start()
    {
        animator = GetComponent<Animator>();
        var healthBar = this.gameObject.transform.GetChild(1);
        playerHealth = healthBar.GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    float playerMovementAnimationSpeed(){
        float horizontalMovement = Mathf.Abs(playerMovement.moveHorziontal);
        float verticalMovement = Mathf.Abs(playerMovement.moveVertical);
        return Mathf.Max(horizontalMovement, verticalMovement);
    }
    
    void FixedUpdate(){
        animator.ResetTrigger("dead");
        if(playerHealth.hp <= 0 && !playerStatus.isDead){
            animator.SetTrigger("dead");
            playerStatus.isDead = true;
        }
        animator.SetFloat("speed", playerMovementAnimationSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = Input.GetKeyDown(KeyCode.Space) && !playerStatus.isDead;
        animator.SetBool("isAttacking", isAttacking); 

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", true);
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", false);
        }
    }
}
