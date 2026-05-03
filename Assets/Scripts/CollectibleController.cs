using TMPro;
using UnityEngine;

/*****************************************************************************
// File Name : CollectibleController.cs
// Author : Ryan Blanco
// Creation Date : March 18, 2026
//
// Brief Description : Controller for our collectables. 
*****************************************************************************/
public class CollectibleController : MonoBehaviour
{
    
    [SerializeField] private TMP_Text collectibleText;

    [SerializeField] private AudioSource collectSound;

    // how many collectibles the player has collected
    private int collectibleCount;

    //  reference to the CollectibleManager so we can notify it
    private CollectibleManager manager;
    private int totalCollectibles;

 
    /// <summary>
    /// start
    /// </summary>
    // Sets the starting collectible count and updates the UI text
    void Start()
    {
        collectibleCount = 0;
        collectibleText.text = "Collectibles: " + collectibleCount.ToString();

        //  find the manager in the scene
        manager = FindAnyObjectByType<CollectibleManager>();

        totalCollectibles = manager.TotalCollectibles;
        collectibleText.text = "Collectibles: " + collectibleCount + " / " + totalCollectibles;

    }
   
    /// <summary>
    /// Detects when the player touches a collectible and increases the count
    /// </summary>
    /// <param name="triggerObject">The object that entered the trigger</param>
    private void OnTriggerEnter(Collider triggerObject)
    {
        // Checks if the object has the correct tag for collectibles
        if (triggerObject.gameObject.CompareTag("CollectibleTag"))
        {
            // Increase the collectible count
            collectibleCount++;

            // Update the UI text to show the new total
            collectibleText.text = "Collectibles: " + collectibleCount + " / " + totalCollectibles;



            if (collectSound != null)
            {
                collectSound.Play();
            }

            // notify the manager that a collectible was collected
            manager.AddCollectible();   // added

            // Remove the collectible from the scene
            Destroy(triggerObject.gameObject);
        }
    }
}








