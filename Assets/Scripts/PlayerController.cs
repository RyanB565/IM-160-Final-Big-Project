using System;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

/*****************************************************************************
 // File Name      : PlayerController.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 18, 2026
 //
 // Brief Description : Controller so that we can controll the player also so that we roate with the camera and
//                       does checkpoints
 *****************************************************************************/

public class PlayerController : MonoBehaviour
{

    private InputAction move;
    private Vector3 playerMovement;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed = 10f;
    public bool isClimbing;
    public Vector3 respawnPoint;
    private bool canDetectWater = true;
    private bool ignoreWater = false;

    // Tutorial triggers
    public bool hasMoved = false;
    public bool hasUsedInvisibility = false;
    public bool avoidedSpikes = false;
    public bool avoidedWater = false;
    public bool reachedTutorialCheckpoint = false;
    public bool collectedTutorialGold = false;
    public bool reachedPlatform = false;
    public bool usedLadder = false;
    public bool hasUsedLightning = false;








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
       

        move.performed += MovePerformed;
        move.canceled += MoveCanceled;

        respawnPoint = transform.position;
        Debug.Log("START RESPAWN POINT: " + respawnPoint);

    }




    /// <summary>
    /// MoveCaneled
    /// </summary>
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }
    /// <summary>
    /// MovePerformed
    /// </summary>
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = obj.ReadValue<Vector2>().x * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().y * playerSpeed;
        //playerspeed here so as not to affect vertical movement
    }


    /// <summary>
    /// update
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (isClimbing)
        {
            // Do not apply normal movement while climbing
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            return;
        }

        // so that player can move with camera 
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 plane = Vector3.ProjectOnPlane(cameraForward, Vector3.up);
        Quaternion oriantation = Quaternion.LookRotation(plane);
        transform.rotation = Quaternion.Slerp(transform.rotation, oriantation, rotationSpeed * Time.deltaTime);

        Vector3 rotatedMovement = playerMovement;

        rotatedMovement = oriantation * rotatedMovement;
        rb.linearVelocity = new Vector3(rotatedMovement.x, rb.linearVelocity.y, rotatedMovement.z);

        Vector3 lookDir = new Vector3(rotatedMovement.x, 0f, rotatedMovement.z);
        if (lookDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        if (playerMovement.x != 0 || playerMovement.z != 0)
        {
            hasMoved = true;
        }




    }

    /// <summary>
    /// respans player if they were killed by these and detecs respawn 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        // checkpoint reached update respawn position
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
             
            Debug.Log("CHECKPOINT SET TO: " + respawnPoint);

        }

        // water hit respawn player
        if (other.CompareTag("WaterTag")  && !ignoreWater)
        {
            Respawn();
        }

        // enemy hit respawn player
      
        if (other.CompareTag("EyeballEnemy") || other.CompareTag("EnemyTag"))
        {
            Respawn();
        }

       
    }

    /// <summary>
    /// cooldown for water
    /// </summary>
    /// <returns></returns>
    private System.Collections.IEnumerator WaterCooldown()
    {
        canDetectWater = false;
        yield return new WaitForSeconds(0.2f);
        canDetectWater = true;
    }

    /// <summary>
    /// ignores water after death
    /// </summary>
    /// <returns></returns>
    private IEnumerator IgnoreWater()
    {
        ignoreWater = true;
        yield return new WaitForSeconds(0.3f); // ignore water for 0.3 seconds
        ignoreWater = false;
    }


    /// <summary>
    /// Respawn
    /// </summary>
    public void Respawn() //lets the plaayer respawn to checkpoints
    {

        Debug.Log("RESPAWNING AT: " + respawnPoint);
        transform.position = respawnPoint;
        rb.linearVelocity = Vector3.zero;
        StartCoroutine(WaterCooldown());
        StartCoroutine(IgnoreWater());


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    /// <summary>
    /// Deactivates/Removes the inputs
    /// </summary>
    private void OnDestroy()
    {
        move.performed -= MovePerformed;
        move.canceled -= MoveCanceled;

        
    }

}

