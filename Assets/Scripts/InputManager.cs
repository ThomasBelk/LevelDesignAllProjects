using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] Movement movementScript;
    [SerializeField] CameraController cameraController;

    private Vector2 movement;
    private Vector2 mouseMovement;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Movement.performed += context => movement = context.ReadValue<Vector2>();

        playerInput.Player.MouseX.performed += context => mouseMovement.x = context.ReadValue<float>();
        playerInput.Player.MouseY.performed += context => mouseMovement.y = context.ReadValue<float>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        movementScript.ReciveInput(movement);
        cameraController.ReceiveInput(mouseMovement);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
