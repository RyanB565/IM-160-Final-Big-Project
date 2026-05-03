using UnityEngine;

/*****************************************************************************
// File Name : Checkpoint.cs
// Author : Ryan Blanco
// Creation Date : April 29, 2026
//
// Brief Description :  checkpoint trigger
*****************************************************************************/


public class Checkpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 checkpointPosition;
    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        checkpointPosition = transform.position;


    }


   
}
