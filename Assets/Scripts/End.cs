
using UnityEditor;
using UnityEngine;
/******************************************************************************
// File Name : End.cs
// Author : Ryan Blanco
// Creation Date : March 21, 2026
//
// Brief Description : Ends game once you press button 
******************************************************************************/
public class End : MonoBehaviour
{
    /// <summary>
    /// quits the game and stops in unity
    /// </summary>
    public void QuitGame()
    {
# if UNITY_EDITOR
        // exit in editor 
        EditorApplication.isPlaying = false;

#else
        // quits the build 
        Application.Quit();
#endif
    }
}