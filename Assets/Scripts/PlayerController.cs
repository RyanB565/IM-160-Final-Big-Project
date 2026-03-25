using System;
using UnityEngine;
using UnityEngine.InputSystem;

/*****************************************************************************
 // File Name      : PlayerController.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 18, 2026
 //
 // Brief Description : Controller so that we can controll the player also so that we roate with the camera 
 *****************************************************************************/

public class PlayerController : MonoBehaviour
{

    private InputAction move;
    private Vector3 playerMovement;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed = 10f;
    public bool isClimbing; 


  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
       

        move.performed += MovePerformed;
        move.canceled += MoveCanceled;

       
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

        Vector3 rotatedMovement = playerMovement;

        rotatedMovement = oriantation * rotatedMovement;
        rb.linearVelocity = new Vector3(rotatedMovement.x, rb.linearVelocity.y, rotatedMovement.z);


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

