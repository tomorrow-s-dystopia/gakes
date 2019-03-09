using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;

    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    float playerMovementAnimationSpeed(){
        float horizontalMovement = Mathf.Abs(playerMovement.moveHorziontal);
        float verticalMovement = Mathf.Abs(playerMovement.moveVertical);
        Debug.Log(horizontalMovement);
        return Mathf.Max(horizontalMovement, verticalMovement);
    }
    
    void FixedUpdate(){
        if(playerHealth.hp <= 0){
            animator.SetTrigger("dead");
        }
        
        animator.SetFloat("speed", playerMovementAnimationSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = Input.GetKeyDown(KeyCode.Space);
        animator.SetBool("isAttacking", isAttacking); 

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", true);
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", false);
        }
    }
}
