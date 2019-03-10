using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    private MeleeTargets meleeTargets;
    // Start is called before the first frame update
    void Start()
    {
        meleeTargets = GetComponent<MeleeTargets>();
    }

    void MeleeAttack(){
        List<HealthSystem> targets = meleeTargets.Targets;
        foreach(HealthSystem target in targets){
            target.DecreaseHealth(13);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            MeleeAttack();
        }
    }
}
