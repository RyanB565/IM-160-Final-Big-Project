/******************************************************************************
// File Name : PlayerInvisibility.cs
// Author : Ryan Blanco
// Creation Date : March 19, 2026
//
// Brief Description : Lets the player toggle invisibility on and off.
//                     Enemies check this state to decide if they can kill
//                     the player.
******************************************************************************/




using System.Collections;
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

    [SerializeField] private float cooldownTime = 3f;
    private bool onCooldown = false;
    [SerializeField] private float invisDuration = 5f;


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
    /// turn player invisible and starts timer
    /// </summary>

    private void ActivateInvisibility()   
    {
        isInvisible = true;
        meshRenderer.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("PlayerInvisible");

        StartCoroutine(InvisibilityTimer());   
    }


    /// <summary>
    /// invisibility duration and then makes player visible agian
    /// </summary
    private IEnumerator InvisibilityTimer()   
    {
        yield return new WaitForSeconds(invisDuration);

        isInvisible = false;
        meshRenderer.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("PlayerVisible");
    }

    /// <summary>
    /// update
    /// </summary>
    // Check for invisibility toggle input
    void Update()
    {
        if (Input.GetKeyDown(invisibilityKey) && !onCooldown)
        {
            ActivateInvisibility();
        }
    }

    /// <summary>
    /// Couroutine for invisibilty cooldown
    /// </summary>
    private IEnumerator InvisibilityCooldown() 
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
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

        StartCoroutine(InvisibilityCooldown());
    }
   


}
