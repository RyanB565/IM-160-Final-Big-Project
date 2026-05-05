/******************************************************************************
// File Name : PuaseManager.cs
// Author : Ryan Blanco
// Creation Date : March 21, 2026
//
// Brief Description : manager for my pause menu  
******************************************************************************/




using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public GameObject pauseMenuUI;

    private bool isPaused = false;
    public bool IsPaused
    {
        get { return isPaused; }
    }



    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        // This checks if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is paused, resume it
            if (isPaused)
            {
                ResumeGame();
            }
            // If the game is not paused, pause it
            else
            {
                PauseGame();
            }
        }
    }
    /// <summary>
    /// Resumes the game 
    /// </summary>
    // This hides the pause menu and unpauses the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    /// <summary>
    /// Puases game 
    /// </summary>
    // This shows the pause menu and pauses the game
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    /// <summary>
    /// Exits game 
    /// </summary>
    // This closes the game when the player presses the Exit button
    public void ExitGame()
    {
        Application.Quit();

      
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }



}
