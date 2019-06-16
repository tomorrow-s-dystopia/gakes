using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int currentHp;
    public int maxHp = 100;

    private PersonalHealthUI healthUi;
   //private HealthText healthText;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthUi = gameObject.transform.Find("HealthBarContainer").GetComponent<PersonalHealthUI>();
    }

    // Update is called once per frame
   public void DecreaseHealth(int damage){
        currentHp = Mathf.Max(currentHp - damage, 0);

        healthUi.UpdateHealth(maxHp, currentHp);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
