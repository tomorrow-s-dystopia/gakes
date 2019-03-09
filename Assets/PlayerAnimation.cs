using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    
    void FixedUpdate(){
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        animator.SetBool("isWalking", isMoving);

        bool isAttacking = Input.GetKeyDown(KeyCode.Space);
        animator.SetBool("isAttacking", isAttacking); 

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", true);
        }

        
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("isBlocking", false);
        }

        if(playerHealth.hp <= 0){
            animator.SetTrigger("dead");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
