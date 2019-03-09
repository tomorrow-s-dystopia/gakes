using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody2d;
    private bool goingVertical = false;
    private bool goingHorizontal = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void isVerticalKeysPressed(){
        bool keyPressed = Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.S);
        bool keyUnPressed = Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp(KeyCode.S);
        goingVertical = goingVertical ? !keyUnPressed : keyPressed;
    }

    void isHorizontalKeysPressed(){
        bool keyPressed = Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown(KeyCode.D);
        bool keyUnPressed = Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp(KeyCode.D);
        goingHorizontal = goingHorizontal ? !keyUnPressed : keyPressed;
    }

    void FixedUpdate(){
        isVerticalKeysPressed();
        isHorizontalKeysPressed();
        float moveVertical = goingVertical ? Input.GetAxis("Vertical") : 0;
        float moveHorziontal = goingHorizontal ? Input.GetAxis("Horizontal") : 0;
        Vector2 movement = new Vector2(moveHorziontal, moveVertical);
        rigidBody2d.velocity = movement * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
     /*    translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
