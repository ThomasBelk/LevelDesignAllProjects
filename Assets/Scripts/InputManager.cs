using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] Movement movementScript;
    [SerializeField] CameraController cameraController;
    [SerializeField] Interactor interactor;

    private Vector2 movement;
    private Vector2 mouseMovement;
    private bool interactPress;
    private bool dropPress;
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
        interactPress = playerInput.Player.InteractButton.WasPressedThisFrame();
        dropPress = playerInput.Player.DropButton.WasPressedThisFrame();
        movementScript.ReciveInput(movement);
        cameraController.ReceiveInput(mouseMovement);
        interactor.RecieveInput(interactPress, dropPress);
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
