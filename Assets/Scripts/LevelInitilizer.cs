/*****************************************************************************
 // File Name      : LevelInitializer.cs
 // Author         : Ryan Blanco
 // Creation Date  : April 14, 2026
 //
 // Brief Description :
 // Sets the current level number when the scene loads. Used by LevelManager
 // to enable or disable level‑specific features.
 *****************************************************************************/




using UnityEngine;

public class LevelInitilizer : MonoBehaviour
{
    public int levelNumber = 2; //lvel number 

   
    /// <summary>
    /// Start
    /// </summary>
    void Start() // assings level number to level manager
    {
        LevelManager.currentLevel = levelNumber;
    }
}
