using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float reloadDelay;
    [SerializeField] private float lowestYPos;
    [SerializeField] private AudioSource deadSound;
    private bool isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;   //coz your not dead at the begining of the game
    }

    // die if you toch enemy 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyTag"))
        {
            Die();
        }
    }

    // die if you touch water (trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterTag"))
        {
            Die();
        }
    }



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
    private void Update()
    {
        if (transform.position.y < lowestYPos && !isDead)
        {
            Die();
        }
    }
}
