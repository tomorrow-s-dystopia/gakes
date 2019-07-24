using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public bool win = false;
    public bool death = false;

    public GameObject deathScreen;

    public GameObject winScreen;
    void Update()
    {
        if (win)
        {
            winScreen.SetActive(true);
        }
        else if (death)
        {
            deathScreen.SetActive(true);
        }

    }
}
