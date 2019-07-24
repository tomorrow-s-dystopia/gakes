using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCondition : MonoBehaviour
{

    private GameObject deathScreen;

    private GameStatus gameStatus;

    bool isActive = false;

    void Start(){
        deathScreen = GameObject.Find("DeathScreen");
        gameStatus = GameObject.Find("EventSystem").GetComponent<GameStatus>();
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited!");
        Application.Quit();
    }

    public void LoadMenu()
    {
        Debug.Log("Went Back To Menu!");
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        Debug.Log("Restart Game!");
        SceneManager.LoadScene("Game");
    }
}
