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

    private PlayerTracker tracker;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemyHealth = GetComponent<HealthSystem>();
        status = GetComponent<EnemyStatus>();
        tracker = GetComponentInChildren<PlayerTracker>();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveHorziontal, MoveVertical) * Speed;
        enemyBody.velocity = movement;
    }

    void LateUpdate()
    {
        bool isBusy = status.isDying || status.isDead
        || status.isAttacking || status.isPlayerDead;
        if (isBusy)
        {
            MoveHorziontal = 0;
            MoveVertical = 0;
            return;
        }

        MoveHorziontal = tracker.DistanceHorziontal;
        MoveVertical = tracker.DistanceVertical;
    }
}
