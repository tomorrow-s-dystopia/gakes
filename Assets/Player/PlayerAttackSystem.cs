using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    private MeleeTargets meleeTargets;
    private HealthSystem health;
    private PlayerStatus status;
    private bool isBlocking;
    // Start is called before the first frame update
    void Start()
    {
        meleeTargets = GetComponent<MeleeTargets>();
        health = GetComponent<HealthSystem>();
        status = GetComponent<PlayerStatus>();
        isBlocking = false;
    }

    void MeleeAttack(){
        Debug.Log("player attacking");
        List<HealthSystem> targets = meleeTargets.Targets;
        foreach(HealthSystem target in targets){
            target.DecreaseHealth(13);
        }
    }

    public bool Defend(int damage)
    {
        Debug.Log("player defending");
        if (isBlocking) return true;

        health.DecreaseHealth(damage);
        return health.Hp > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (status.isDead){
            isBlocking = false;
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isBlocking){
            MeleeAttack();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isBlocking = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isBlocking = false;
        }

        status.isBlocking = isBlocking;
    }
}
