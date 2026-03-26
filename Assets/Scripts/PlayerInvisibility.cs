/******************************************************************************
// File Name : PlayerInvisibility.cs
// Author : Ryan Blanco
// Creation Date : March 19, 2026
//
// Brief Description : Lets the player toggle invisibility on and off.
//                     Enemies check this state to decide if they can kill
//                     the player.
******************************************************************************/




using UnityEngine;

public class PlayerInvisibility : MonoBehaviour
{

    // Key used to toggle invisibility
    [SerializeField] private KeyCode invisibilityKey = KeyCode.E;

    // Tracks if the player is invisible
    private bool isInvisible = false;

    // Used to hide or show the player
    private MeshRenderer meshRenderer;

    // Allows other scripts to check invisibility
    public bool IsInvisible
    {
        get { return isInvisible; }
    }

    // Get the MeshRenderer at the start of the game
    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    /// <summary>
    /// Update
    /// </summary>
    // Check for invisibility toggle input
    void Update()
    {
        if (Input.GetKeyDown(invisibilityKey))
        {
            ToggleInvisibility();
        }
    }
    /// <summary>
    /// Toggle Invisibility
    /// </summary>
    // Turns invisibility on or off
    private void ToggleInvisibility()
    {
        isInvisible = !isInvisible;

        // Hide the player when invisible
        meshRenderer.enabled = !isInvisible;

        if (isInvisible)
            gameObject.layer = LayerMask.NameToLayer("PlayerInvisible"); // player is invisible for enemy to kill
        else
            gameObject.layer = LayerMask.NameToLayer("PlayerVisible"); // player is visible for enemy to kill


    }



}
