using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameStatus gameStatus;

    public GameObject RestartButton;
    public GameObject MenuButton;
    public GameObject ExitButton;

    void Start()
    {
        gameStatus = GameObject.Find("EventSystem").GetComponent<GameStatus>();
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited!");
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Went Back To Menu!");
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("Restart Game!");
        SceneManager.LoadScene("Game");
    }

    void ToggleWinScreen()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        RestartButton.SetActive(true);
        MenuButton.SetActive(true);
        ExitButton.SetActive(true);
    }
    void Update()
    {
        if (!gameIsPaused)
        {
            Invoke("ToggleWinScreen", 2);
        }
    }
}
