using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyBody;

    private HealthSystem enemyHealth;
    public float Speed = 1.2f;
    public float MoveVertical = 0f;
    public float MoveHorziontal = 0f;
    private EnemyStatus status;

    public GameObject target;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemyHealth = GetComponent<HealthSystem>();
        status = GetComponent<EnemyStatus>();
        target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveHorziontal, MoveVertical) * Speed;
        enemyBody.velocity = movement;
    }

    void Update()
    {
        if (status.isDying || status.isDead)
        {
            MoveHorziontal = 0;
            MoveVertical = 0;
            return;
        }

        MoveHorziontal = target.transform.position.x - transform.position.x;
        MoveVertical = target.transform.position.y - transform.position.y;
    }
}
