using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    public bool isPlayerDead;
    public bool isAggro;

    private AudioSource dyingSound;

    void Start()
    {
        isDead = false;
        isAttacking = false;
        isMoving = false;
        isPlayerDead = false;
        isAggro = false;
        dyingSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isDying)
             dyingSound.Play();
    }
}
