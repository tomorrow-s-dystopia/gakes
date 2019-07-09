using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuUI;

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited!");
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
