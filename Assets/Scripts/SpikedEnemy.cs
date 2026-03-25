using UnityEngine;
/*****************************************************************************
 // File Name      : SpikedEnemy.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 21, 2026
 //
 // Brief Description : Enemy tthat kills player if they are not visible
 *****************************************************************************/
public class SpikedEnemy : MonoBehaviour
{
    /// <summary>
    /// checks for collison if player is visible and kills if they are not
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // colliding object is  the player
        {
            PlayerInvisibility invis = collision.gameObject.GetComponent<PlayerInvisibility>();

            if (invis != null && !invis.IsInvisible) // if player is visible die
            {
                collision.gameObject.GetComponent<PlayerLife>().SendMessage("Die");
            }
        }
    }

}
