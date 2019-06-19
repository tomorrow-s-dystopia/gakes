using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public bool isDead;
    public bool isDying;
    public bool isAttacking;

    public bool isMoving;
    void Start()
    {
        isDead = false;
        isAttacking = false;
        isMoving = false;
    }

    public void onDeath()
    {
        isDead = true;
        isDying = false;
        isAttacking = false;
        isMoving = false;
    }
}
