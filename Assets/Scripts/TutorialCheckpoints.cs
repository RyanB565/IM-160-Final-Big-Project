using UnityEngine;

/******************************************************************************
// File Name : TutorialCheckpoints.cs
// Author : Ryan Blanco
// Creation Date : May 3, 2026
//
// Brief Description : universal script for checkpoinsts in tutorial 
******************************************************************************/

public class TutorialCheckpoints : MonoBehaviour
{
    
    public string tutorialcheckpoints = "";


    /// <summary>
    /// checkpopints for tutorial
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider checkpoint)
    {
        if (checkpoint.CompareTag("Player"))
        {
            PlayerController p = checkpoint.GetComponent<PlayerController>();

            if (tutorialcheckpoints == "Spikes")
            {
                p.avoidedSpikes = true;
            }
            else if (tutorialcheckpoints == "Water")
            {
                p.avoidedWater = true;
            }
            else if (tutorialcheckpoints == "Checkpoint")
            {
                p.reachedTutorialCheckpoint = true;
            }
            else if (tutorialcheckpoints == "Gold")
            {
                p.collectedTutorialGold = true;
            }
            else if (tutorialcheckpoints == "Platform")
            {
                p.reachedPlatform = true;
            }
            else if (tutorialcheckpoints == "Ladder")
            {
                p.usedLadder = true;
            }

        }
    }
}
