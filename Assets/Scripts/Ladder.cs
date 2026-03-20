/******************************************************************************
// File Name : Ladder.cs
// Author : Ryan Blanco
// Creation Date : March 20, 2026
//
// Brief Description : Lets the player climb ladders by turning off gravity
//                     and allowing vertical movement while inside the ladder
//                     trigger zone.
******************************************************************************/

using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Speed the player climbs the ladder
    [SerializeField] private float climbSpeed = 3f;

    // Tracks if the player is climbing
    private bool isClimbing;

    // Reference to the player's Rigidbody
    private Rigidbody playerRb;

    // When the player enters the ladder trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            playerRb.useGravity = false;

            // Tell PlayerController to stop normal movement
            other.GetComponent<PlayerController>().isClimbing = true;

            isClimbing = true;
        }
    }

    // When the player exits the ladder trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb.useGravity = true;

            // Re-enable normal movement
            other.GetComponent<PlayerController>().isClimbing = false;

            isClimbing = false;
        }
    }

    // While the player stays inside the ladder trigger
    private void OnTriggerStay(Collider other)
    {
        if (isClimbing && other.CompareTag("Player"))
        {
            // Get vertical input (W/S keys)
            float vertical = Input.GetAxis("Vertical");

            // Move the player up or down the ladder
            Vector3 climbMovement = new Vector3(0f, vertical * climbSpeed, 0f);
            other.transform.Translate(climbMovement * Time.deltaTime);
        }
    }
}
