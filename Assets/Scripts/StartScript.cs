using UnityEngine;
using UnityEngine.SceneManagement;
/******************************************************************************
// File Name : End.cs
// Author : Ryan Blanco
// Creation Date : March 21, 2026
//
// Brief Description : start and ends game once you press buttons
******************************************************************************/
public class StartScript : MonoBehaviour
{
    /// <summary>
    /// start games 
    /// </summary>
    public void StartGame()
    {
        // Loads the first level in the Build Settings
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// ends game 
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Exit play mode in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the built game
        Application.Quit();
#endif
    }
}
