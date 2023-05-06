using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        // Make sure the pause menu is hidden at the start of the game
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // If the player presses the Escape key, show/hide the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Freeze the game and show the pause menu
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        // Unfreeze the game and hide the pause menu
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

}