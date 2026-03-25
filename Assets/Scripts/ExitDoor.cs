using UnityEngine;
using UnityEngine.SceneManagement;
/*****************************************************************************
 // File Name      : ExitDoor.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 20, 2026
 //
 // Brief Description : tracks collectables and spawns exit once we have all collectables collected and sends to 
// next level
 *****************************************************************************/
public class ExitDoor : MonoBehaviour
{

    /// <summary>
    /// Player loads to next scene
    /// </summary>
    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.name == "Player")
        {
            //Load the next scene from the build profile scene list
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}