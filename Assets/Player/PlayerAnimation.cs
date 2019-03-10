using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private HealthSystem playerHealth;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    private PlayerStatus playerStatus;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<HealthSystem>();
        playerMovement = GetComponent<PlayerMovement>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    float PlayerMovementAnimationSpeed(){
        float horizontalMovement = Mathf.Abs(playerMovement.MoveHorziontal);
        float verticalMovement = Mathf.Abs(playerMovement.MoveVertical);
        return Mathf.Max(horizontalMovement, verticalMovement);
    }
    
    void FixedUpdate(){
        animator.ResetTrigger("dead");
        if(playerHealth.Hp <= 0 && !playerStatus.IsDead){
            animator.SetTrigger("dead");
            playerStatus.IsDead = true;
        }
        animator.SetFloat("speed", PlayerMovementAnimationSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = Input.GetKeyDown(KeyCode.Space) && !playerStatus.IsDead;
        animator.SetBool("isAttacking", isAttacking); 

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", true);
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", false);
        }
    }
}
