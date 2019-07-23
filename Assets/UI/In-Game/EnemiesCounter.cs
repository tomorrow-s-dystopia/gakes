using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesCounter : MonoBehaviour
{
    private TextMeshProUGUI textObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyStatus[] enemies = GameObject.FindObjectsOfType<EnemyStatus>();
        int numberOfLiveEnemies = 0;
        foreach(EnemyStatus enemy in enemies){
            if(!enemy.isDead){
                numberOfLiveEnemies++;
            }
        }
        textObject.SetText("Enemis Left : {0}", numberOfLiveEnemies);
    }
}
