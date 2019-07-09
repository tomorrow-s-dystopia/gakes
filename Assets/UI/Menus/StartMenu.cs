using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public bool GameIsUp;


    public GameObject StartMenuUI;

    void Start()
    {
        Time.timeScale = 0f;
        GameIsUp = true;
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited!");
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        GameIsUp = true;
        SceneManager.LoadScene("Game");
    }
}
