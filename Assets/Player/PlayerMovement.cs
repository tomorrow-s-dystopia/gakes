using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1.2f;
    public float MoveVertical = 0f;
    public float MoveHorziontal = 0f;
    private Rigidbody2D playerBody;
    private HealthSystem playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<HealthSystem>();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveHorziontal, MoveVertical) * Speed;
        playerBody.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        bool isDying = playerHealth.currentHp <= 0;
        MoveVertical = isDying ? 0 : Input.GetAxisRaw("Vertical");
        MoveHorziontal = isDying ? 0 : Input.GetAxisRaw("Horizontal");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
