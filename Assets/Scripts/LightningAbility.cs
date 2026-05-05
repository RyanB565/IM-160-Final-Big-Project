/******************************************************************************
// File Name : LightningAbility.cs
// Author : Ryan Blanco
// Creation Date : April 13, 2026
//
// Brief Description : Lets the player shoot a lightning  from 
//                     spawn point. Lightning has a cooldown and only damages
//                     eyeball enemies.
******************************************************************************/


using UnityEngine;

public class LightningAbility : MonoBehaviour
{

    // Prefab of the lightning bolt
    [SerializeField] private GameObject lightningPrefab;

    // Where the lightning spawns from
    [SerializeField] private Transform spawnPoint;

    // Speed of the lightning bolt
    [SerializeField] private float lightningSpeed = 20f;

    // Cooldown between shots
    [SerializeField] private float shootCooldown = 1f;
    private bool onCooldown = false;
    [SerializeField] private Transform cameraTransform;
    private PlayerController playerController;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }



    /// <summary>
    /// Update
    /// </summary>
    // checks for rc input and shoots lighting if not on cooldown also locks lightning until lvl 2 and onward
    // also moves lighting spawnpoint with camera
    void Update()
    {
        spawnPoint.rotation = cameraTransform.rotation;

        // Lightning unlocks at level 2 and onward
        if (LevelManager.currentLevel < 2)
            return;

        // Left-click shoot lightning
        if (Input.GetKeyDown(KeyCode.Mouse0) && onCooldown == false)
        {
            playerController.hasUsedLightning = true;

            ShootLightning();
        }

    }
    /// <summary>
    /// Spawns the lightning prefab and moves it 
    /// </summary>
    // spawns lightning 
    private void ShootLightning()
    {


        onCooldown = true;
        Invoke("ResetCooldown", shootCooldown);

        
        Vector3 shootDirection = cameraTransform.forward;

        GameObject bolt = Instantiate(lightningPrefab, spawnPoint.position, spawnPoint.rotation);

        

        Rigidbody rb = bolt.GetComponentInChildren<Rigidbody>();
        rb.linearVelocity = shootDirection * lightningSpeed;

       
    }
    /// <summary>
    /// Allows player to shoot lightning agian
    /// </summary>
    private void ResetCooldown()
    {
        onCooldown = false;
    }
    
}
