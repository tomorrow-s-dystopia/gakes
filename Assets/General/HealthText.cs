using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI textObject;
    public int currentHp;
    public int maxHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        textObject = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textObject.SetText("{0}/{1}", currentHp, maxHp);
    }
}
