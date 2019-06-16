using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Hp;
    public int MaxHealth = 100;

    private PersonalHealthUI healthUi;


    // Start is called before the first frame update
    void Start()
    {
        Hp = MaxHealth;
        healthUi = gameObject.transform.Find("HealthBarContainer/HealthBar").GetComponent<PersonalHealthUI>();
    }

    // Update is called once per frame
   public void DecreaseHealth(int damage){
        Hp = Mathf.Max(Hp - damage, 0);

        healthUi.DecreaseHealthBar(MaxHealth, Hp);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
