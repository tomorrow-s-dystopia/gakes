using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalHealthUI : MonoBehaviour
{
    private Transform healthBarTransform;

    private Vector3 healthBarScaleVector;
    private Vector2 healthBarPositionVector;
    private float maxScaleX; 
    // Start is called before the first frame update
    void Start()
    {
        healthBarTransform = GetComponent<Transform>();
        healthBarPositionVector = healthBarTransform.localPosition;
        healthBarScaleVector = healthBarTransform.localScale;
        maxScaleX = healthBarTransform.localScale.x;
    }

    public void decreaseHealthBar(int maxHealth, int hp){
        float healthPercentage = (hp % maxHealth) * 0.01f;
        Debug.Log(healthPercentage);
        healthBarScaleVector.x = maxScaleX * healthPercentage;  
        healthBarPositionVector.x = 0.5f * (healthBarScaleVector.x - maxScaleX);

        healthBarTransform.localScale = healthBarScaleVector;
        healthBarTransform.localPosition = healthBarPositionVector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
