using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    private CharacterController characterController;
    public GameManager gameManager;

    private Vector2 playerMovementInput;
    private Vector3 playerMovementStrafe;
    private Vector3 playerMovementForward;
    private bool isMoving;
    [SerializeField] private float playerVelocity;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        characterController = GetComponent<CharacterController>();

        playerInputSystem.Player.Movement.started += OnMovementInput;
        playerInputSystem.Player.Movement.canceled += OnMovementInput;
        playerInputSystem.Player.Movement.performed += OnMovementInput;
    }

    private void FixedUpdate()
    {
        if (gameManager.gameIsRunning)
        {
            SetMovement();
        }
    }

    private void SetMovement()
    {
        playerMovementForward = playerMovementInput.y * playerVelocity * transform.forward;
        playerMovementStrafe = playerMovementInput.x * playerVelocity * transform.right;

        Vector3 finalMovement = playerMovementForward + playerMovementStrafe;
        characterController.Move(finalMovement * Time.deltaTime);
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        playerMovementInput = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        playerInputSystem.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputSystem.Player.Disable();
    }
}
