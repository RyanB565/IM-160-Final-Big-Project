using UnityEngine;
using TMPro;

/******************************************************************************
// File Name : TutorialManager.cs
// Author : Ryan Blanco
// Creation Date : May 3, 2026
//
// Brief Description : Tutorial manager that manages and sends text to screen
******************************************************************************/

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private PlayerController player;
    [SerializeField] private PauseManager pauseManager;

    private int step = 0;

    void Start()
    {
        tutorialText.text = "Use WASD to move";
    }

    void Update()
    {
        // STEP 0 – Move
        if (step == 0)
        {
            if (player.hasMoved)
            {
                step = 1;
                tutorialText.text = "Press ESC to open the pause menu";
            }
        }

        // STEP 1 – Pause
        else if (step == 1)
        {
            if (pauseManager.IsPaused)
            {
                step = 2;
                tutorialText.text = "Go up the platform";
            }
        }

        // STEP 2 – Platform
        else if (step == 2)
        {
            if (player.reachedPlatform)
            {
                step = 3;
                tutorialText.text = "Climb the ladder";
            }
        }

        // STEP 3 – Ladder
        else if (step == 3)
        {
            if (player.usedLadder)
            {
                step = 4;
                tutorialText.text = "Press E to turn invisible";
            }
        }

        // STEP 4 – Invisibility
        else if (step == 4)
        {
            if (player.hasUsedInvisibility)
            {
                step = 5;
                tutorialText.text = "Avoid the spiked enemy while invisible";
            }
        }

        // STEP 5 – Spikes
        else if (step == 5)
        {
            if (player.avoidedSpikes)
            {
                step = 6;
                tutorialText.text = "Avoid the water — invisibility does NOT protect you";
            }
        }

        // STEP 6 – Water
        else if (step == 6)
        {
            if (player.avoidedWater)
            {
                step = 7;
                tutorialText.text = "Walk into the checkpoint to save your progress";
            }
        }

        // STEP 7 – Checkpoint
        else if (step == 7)
        {
            if (player.reachedTutorialCheckpoint)
            {
                step = 8;
                tutorialText.text = "Collect the gold to unlock the exit door";
            }
        }

        // STEP 8 – Gold
        else if (step == 8)
        {
            if (player.collectedTutorialGold)
            {
                step = 9;
                tutorialText.text = "Go to the exit to finish the tutorial";
            }
        }
    }
}


