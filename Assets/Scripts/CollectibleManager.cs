using UnityEngine;
/*****************************************************************************
 // File Name      : CollectibleManager.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 18, 2026
 //
 // Brief Description : tracks collectables and spawns exit once we have all collectables collected and sends to 
// next level
 *****************************************************************************/
public class CollectibleManager : MonoBehaviour
{
    private int totalCollectibles;

    // How many collectibles the player has collected
    private int collectedCount;

    // Reference to the exit door object
    [SerializeField] private GameObject exitDoor;

    /// <summary>
    /// total collectibles
    /// </summary>
    
    public int TotalCollectibles
    {
        get { return totalCollectibles; }
    }


    /// <summary>
    /// Counts all collectibles in the scene at the start of the game.
    /// </summary>
    private void Start()
    {
        // Count all objects tagged as collectibles
        totalCollectibles = GameObject.FindGameObjectsWithTag("CollectibleTag").Length;

        collectedCount = 0;

        // Make sure the exit starts locked (disabled)
        if (exitDoor != null)
        {
            exitDoor.SetActive(false);
        }
    }

    /// <summary>
    /// Called by the collectible when the player picks it up.
    /// </summary>
    public void AddCollectible()
    {
        collectedCount++;

        // If the player collected everything, unlock the exit
        if (collectedCount >= totalCollectibles)
        {
            UnlockExit();
        }
    }

    /// <summary>
    /// Unlocks the exit door so the player can win.
    /// </summary>
    private void UnlockExit()
    {
        if (exitDoor != null)
        {
            exitDoor.SetActive(true);
        }

        Debug.Log("All collectibles found! Exit unlocked.");
    }





}






    
