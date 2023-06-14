using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    private Rigidbody rigidBody;

    private Vector2 playerMovementInput;
    private Vector3 playerMovement;
    [SerializeField] private float playerVelocity;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        rigidBody = GetComponent<Rigidbody>();

        playerInputSystem.Player.Movement.started += OnMovementInput;
        playerInputSystem.Player.Movement.canceled += OnMovementInput;
        playerInputSystem.Player.Movement.performed += OnMovementInput;
    }

    private void FixedUpdate()
    {
        SetMovement();
    }

    private void SetMovement()
    {
        transform.Translate(playerMovement * playerVelocity * Time.deltaTime);
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        playerMovementInput = context.ReadValue<Vector2>();
        playerMovement = new Vector3(playerMovementInput.x, 0f, playerMovementInput.y);
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
