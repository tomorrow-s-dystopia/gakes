using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesCounter : MonoBehaviour
{
    private TextMeshProUGUI textObject;

    private GameStatus gameStatus;
    void Start()
    {
        textObject = gameObject.GetComponent<TextMeshProUGUI>();
        gameStatus = GameObject.Find("EventSystem").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus.win || gameStatus.death)
        {
            return;
        }

        EnemyStatus[] enemies = GameObject.FindObjectsOfType<EnemyStatus>();
        int numberOfLiveEnemies = 0;
        foreach (EnemyStatus enemy in enemies)
        {
            if (!enemy.isDead)
            {
                numberOfLiveEnemies++;
            }
        }
        textObject.SetText("Enemis Left : {0}", numberOfLiveEnemies);
        if (numberOfLiveEnemies == 0)
        {
            gameStatus.win = true;
        }
    }
}
