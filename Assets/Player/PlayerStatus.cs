using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    public GameStatus gameStatus;
    public bool isBlocking;
    void Start()
    {
        isDead = false;
        gameStatus = GameObject.Find("EventSystem").GetComponent<GameStatus>();
    }

    void Update()
    {
        gameStatus.death = isDead;

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<HealthSystem>().DecreaseHealth(13);
        }

        if (!isBlocking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            isBlocking = true;
        }

        if (isBlocking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            isBlocking = false;
        }

        if (!isBlocking && Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
        }

        if (isAttacking && Input.GetKeyUp(KeyCode.Space))
        {
            isAttacking = false;
        }
    }
}
