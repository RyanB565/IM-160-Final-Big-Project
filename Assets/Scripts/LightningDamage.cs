/******************************************************************************
// File Name : LightningDamage.cs
// Author : Ryan Blanco
// Creation Date : April 13, 2026
//
// Brief Description : Damages only eyeball enemies when lightning hits them.
******************************************************************************/

using UnityEngine;

public class LightningDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    /// <summary>
    /// checks if lighning hit eyeball enemy and hurts it
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EyeballEnemy"))
        {
            EyeballEnemy enemy = other.GetComponent<EyeballEnemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        // Destroy lightning on any collision
        Destroy(gameObject);
    }
}
