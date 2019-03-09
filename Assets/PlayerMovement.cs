using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.025f;
    private Vector2 movement;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(0,0);
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate(){
        characterController.Move(movement);
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = GetComponent<PlayerHealth>().hp <= 0;
        if(isDead){
            return;
        }
        float moveVertical = Input.GetAxisRaw("Vertical") * speed;
        float moveHorziontal = Input.GetAxisRaw("Horizontal") * speed;
        movement = new Vector2(moveHorziontal, moveVertical);
    }
}
