using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BodyPosition[] playerBodyPositions;
    private AttackPosition attackPosition;
    private HealthSystem playerHealth;
    private PlayerStatus status;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<HealthSystem>();
        status = GetComponent<PlayerStatus>();
        playerBodyPositions = GetComponentsInChildren<BodyPosition>();
        attackPosition = GetComponentInChildren<AttackPosition>();
    }

    private void flip()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        foreach (BodyPosition body in playerBodyPositions)
        {
            body.flip();
        }
                rigid.bodyType = RigidbodyType2D.Dynamic;
        attackPosition.flip();
    }

    // Update is called once per frame
    void Update()
    {
        bool isBusy = status.isDying || status.isDead || status.isBlocking;
        if (isBusy) return;

        bool turningLeft = Input.GetKeyDown(KeyCode.A) && !spriteRenderer.flipX;
        bool turningRight = Input.GetKeyDown(KeyCode.D) && spriteRenderer.flipX;
        if (turningLeft || turningRight)
        {
            flip();
        }
    }
}
