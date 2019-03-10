using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int hp;
    public int maxHealth = 100;

    private PersonalHealthUI healthUI;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHealth;
        healthUI = this.gameObject.transform.GetChild(1).GetComponent<PersonalHealthUI>();
    }

    // Update is called once per frame
   public void decreaseHealth(int damage){
        hp = Mathf.Max(hp - damage, 0);

        healthUI.decreaseHealthBar(maxHealth, hp);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
