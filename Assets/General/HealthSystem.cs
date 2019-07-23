using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int currentHp;
    public int maxHp = 100;

    private PersonalHealthUI healthUi;

    private Status status;

    private DamageSystem damageSystem;

    void Start()
    {
        currentHp = maxHp;
        healthUi = gameObject.transform.Find("HealthBarContainer").GetComponent<PersonalHealthUI>();
        status = GetComponent<Status>();
        damageSystem = GetComponent<DamageSystem>();
    }

    public void DecreaseHealth(int damage)
    {
        if(status.isDying || status.isDead) return;

        int reducedDamage = damageSystem.CalculateDamage(damage);
        
        currentHp = Mathf.Max(currentHp - reducedDamage, 0);
        //Debug.Log(gameObject.tag + "Current Hp is: " + currentHp);
        if (currentHp == 0)
        {
            status.isDying = true;
        }

        healthUi.UpdateHealth(maxHp, currentHp);
    }

    void Update()
    {
    }
}
