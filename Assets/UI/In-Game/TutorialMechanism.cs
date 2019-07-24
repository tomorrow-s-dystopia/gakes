using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMechanism : MonoBehaviour
{
    public bool GameIsPaused = true;
    public GameObject TutorialDialogue;

    void Start()
    {
        TutorialDialogue = GameObject.Find("TutorialScreen");
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (!GameIsPaused) return;

        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TutorialDialogue.SetActive(false);
            GameIsPaused = false;
            Time.timeScale = 1f;
        }
    }
}
