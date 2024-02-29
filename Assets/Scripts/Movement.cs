using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float speed = 11f;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;

    [SerializeField] LayerMask ground;
    private bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, ground);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        } 
        else
        {
            verticalVelocity.y += gravity * Time.deltaTime;
        }

        Vector3 horizonatalVel = (transform.right * movement.x + transform.forward * movement.y) * speed;
        characterController.Move(horizonatalVel * Time.deltaTime);
        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReciveInput(Vector2 input)
    {
        movement = input;
    }
}
