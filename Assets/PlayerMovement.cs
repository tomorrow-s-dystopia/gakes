using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.025f;

    public float moveVertical = 0f;

    public float moveHorziontal = 0f;


    private CharacterController characterController;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        var healthBar = this.gameObject.transform.GetChild(1);
        playerHealth = healthBar.GetComponent<PlayerHealth>();
    }

    void FixedUpdate(){
        Vector2 movement = new Vector2(moveHorziontal,moveVertical);
        characterController.Move(movement);
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = playerHealth.hp <= 0;
        if(isDead){
            return;
        }
        moveVertical = Input.GetAxisRaw("Vertical") * speed;
        moveHorziontal = Input.GetAxisRaw("Horizontal") * speed;
    }
}
