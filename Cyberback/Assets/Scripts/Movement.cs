﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private AnimationCurve jumpFallOff;

    [SerializeField] private Controller controller;

    private CharacterController charController;





    private bool isJumping;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }    
        
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        AxisMovement();

        JumpInput();
    }
          
    private void AxisMovement()
    {

        Vector2 movementQtt = controller.getMovement() * movementSpeed;

        //Vector3 rightMovement = transform.right * horizInput;
        //Vector3 forwardMovement = transform.forward * vertInput;
                   
        charController.SimpleMove(movementQtt/*forwardMovement + rightMovement*/);

        

    }

    private void JumpInput()
    {
        if (controller.IsJumping() && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
