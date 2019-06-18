using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int currentHp;
    public int maxHp = 100;

    private PersonalHealthUI healthUi;

    void Start()
    {
        currentHp = maxHp;
        healthUi = gameObject.transform.Find("HealthBarContainer").GetComponent<PersonalHealthUI>();
    }

    public void DecreaseHealth(int damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);

        healthUi.UpdateHealth(maxHp, currentHp);
    }

    void Update()
    {
    }
}
