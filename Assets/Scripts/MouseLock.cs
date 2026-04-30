using UnityEngine;
/*****************************************************************************
// File Name : MouseLock.cs
// Author : Ryan Blanco
// Creation Date : April 29, 2026
//
// Brief Description : Locks and hides the mouse cursor.
*****************************************************************************/
public class MouseLock : MonoBehaviour
{
    /// <summary>
    /// Start
    /// </summary>
    void Start() // Locks mouse
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
