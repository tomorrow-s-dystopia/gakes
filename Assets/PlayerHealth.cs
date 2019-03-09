using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    public int maxHealth = 100;

    private Transform healthBarTransform;

    private Vector3 healthBarScaleVector;
    private Vector2 healthBarPositionVector;
    private float maxScaleX; 
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHealth;
        healthBarTransform = GetComponent<Transform>();
        healthBarPositionVector = healthBarTransform.localPosition;
        healthBarScaleVector = healthBarTransform.localScale;
        maxScaleX = healthBarTransform.localScale.x;
    }

    void decreaseHealthBar(){
        float healthPercentage = (hp % maxHealth) * 0.01f;
        Debug.Log(healthPercentage);
        healthBarScaleVector.x = maxScaleX * healthPercentage;  
        healthBarPositionVector.x = 0.5f * (healthBarScaleVector.x - maxScaleX);

        healthBarTransform.localScale = healthBarScaleVector;
        healthBarTransform.localPosition = healthBarPositionVector;
    }

    void decreaseHealth(int damage){
        hp = Mathf.Max(hp - damage, 0);

        decreaseHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            decreaseHealth(13);
        }
    }
}
