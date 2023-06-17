using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;
    private CharacterController _characterController;
    [SerializeField] private GameManager _gameManager;

    private Vector2 playerMovementInput;
    private Vector3 playerMovementStrafe;
    private Vector3 playerMovementForward;
    private bool isMoving;
    [SerializeField] private float playerVelocity;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterController = GetComponent<CharacterController>();

        _playerInputSystem.Player.Movement.started += OnMovementInput;
        _playerInputSystem.Player.Movement.canceled += OnMovementInput;
        _playerInputSystem.Player.Movement.performed += OnMovementInput;
    }

    private void FixedUpdate()
    {
        if (_gameManager.GameIsRunning)
        {
            SetMovement();
        }
    }

    private void SetMovement()
    {
        playerMovementForward = playerMovementInput.y * playerVelocity * transform.forward;
        playerMovementStrafe = playerMovementInput.x * playerVelocity * transform.right;

        Vector3 finalMovement = playerMovementForward + playerMovementStrafe;
        _characterController.Move(finalMovement * Time.deltaTime);
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        playerMovementInput = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _playerInputSystem.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Player.Disable();
    }
}
