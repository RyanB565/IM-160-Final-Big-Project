using UnityEngine;
/*****************************************************************************
 // File Name      : StickyPlatform.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 19, 2026
 //
 // Brief Description : allows so that the player sticks to our platform and does not fall off
 *****************************************************************************/
public class StickyPlatform : MonoBehaviour
{

    /// <summary>
    /// sets player to the platform so movement is shared 
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform); // sets the player to the parrent platform

        }
    }
    /// <summary>
    /// Stops so that the pplayer does not share movemnt anymore
    /// </summary>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); // stopts it 

        }
    }

}
