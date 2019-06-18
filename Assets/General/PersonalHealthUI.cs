using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalHealthUI : MonoBehaviour
{
    private HealthText healthText;
    private Transform healthBarTransform;

    private Vector3 healthBarScaleVector;
    private Vector2 healthBarPositionVector;
    private float maxScaleX;
    // Start is called before the first frame update
    void Start()
    {
        healthBarTransform = gameObject.transform.Find("HealthBar");
        healthBarPositionVector = healthBarTransform.localPosition;
        healthBarScaleVector = healthBarTransform.localScale;
        maxScaleX = healthBarTransform.localScale.x;

        healthText = gameObject.transform.Find("HpTextCanvas/HpText").GetComponent<HealthText>();
    }

    private void DecreaseHealthBar(int maxHp, int currentHp)
    {
        float healthPercentage = (currentHp % maxHp) * 0.01f;
        //   Debug.Log(healthPercentage);
        healthBarScaleVector.x = maxScaleX * healthPercentage;
        healthBarPositionVector.x = 0.5f * (healthBarScaleVector.x - maxScaleX);

        healthBarTransform.localScale = healthBarScaleVector;
        healthBarTransform.localPosition = healthBarPositionVector;
    }

    private void updateHealthText(int maxHp, int currentHp)
    {
        healthText.currentHp = currentHp;
        healthText.maxHp = maxHp;
    }

    public void UpdateHealth(int maxHp, int currentHp)
    {
        DecreaseHealthBar(maxHp, currentHp);
        updateHealthText(maxHp, currentHp);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
