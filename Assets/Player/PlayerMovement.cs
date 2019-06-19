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
    private PlayerStatus status;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerHealth = GetComponent<HealthSystem>();
        status = GetComponent<PlayerStatus>();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveHorziontal, MoveVertical) * Speed;
        playerBody.velocity = movement;
    }

    void Update()
    {
        bool isBusy = status.isDying || status.isDead;
        if (isBusy)
        {
            MoveVertical = 0;
            MoveHorziontal = 0;
        }
        else
        {
            MoveVertical = Input.GetAxisRaw("Vertical");
            MoveHorziontal = Input.GetAxisRaw("Horizontal");
        }
    }
}
