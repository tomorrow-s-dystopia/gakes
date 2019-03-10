using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.2f;
    public float moveVertical = 0f;
    public float moveHorziontal = 0f;
    private Rigidbody2D playerBody;
    private HealthSystem playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<HealthSystem>();
    }

    void FixedUpdate(){
        Vector2 movement = new Vector2(moveHorziontal,moveVertical) * speed;
        playerBody.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        bool isDying = playerHealth.hp <= 0;
        moveVertical = isDying ? 0 : Input.GetAxisRaw("Vertical");
        moveHorziontal = isDying ? 0 : Input.GetAxisRaw("Horizontal");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
