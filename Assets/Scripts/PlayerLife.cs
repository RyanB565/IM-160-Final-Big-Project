using System;
using UnityEngine;
using UnityEngine.SceneManagement;
/*****************************************************************************
 // File Name      : PlayerLife.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 18, 2026
 //
 // Brief Description : tracks collectables and spawns exit once we have all collectables collected and sends to 
// next level
 *****************************************************************************/
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float reloadDelay;
    [SerializeField] private float lowestYPos;
    [SerializeField] private AudioSource deadSound;
    private bool isDead;


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        isDead = false;   //coz your not dead at the begining of the game
    }


    /// <summary>
    /// kills player if they toch water
    /// </summary>
    // die if you touch water (trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterTag"))
        {
            Die();
        }
    }


    /// <summary>
    /// Die
    /// </summary>
    private void Die()
    {
        isDead = true;
        deadSound.Play();

        // player can't move 
        GetComponent<Rigidbody>().isKinematic = true; // sets so the plaer is not reponsive to physics 
        GetComponent<PlayerController>().enabled = false;

        // player disappears from scene 
        GetComponent<MeshRenderer>().enabled = false;

        // reload the scene 
        Invoke("ReloadScene", reloadDelay);
    }
    /// <summary>
    /// Reload the curent scene when the player dies 
    /// </summary>
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Checks for player falling off the platform and calls the die function
    /// </summary>

    // Update is called once per frame
    public void Update()
    {
        if (transform.position.y < lowestYPos && !isDead)
        {
            Die();
        }
    }

    /// <summary>
    /// kills the player from enemy collision
    /// </summary>
    public void KillPlayer()
    {
        Die();
    }


}
