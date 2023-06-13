using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    private CharacterController characterController;

    private Transform myCamera;
    private Vector2 playerMovementInput;
    private Vector3 playerMovement;
    [SerializeField] private float playerVelocity;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;

        playerInputSystem.Player.Movement.started += OnMovementInput;
        playerInputSystem.Player.Movement.canceled += OnMovementInput;
        playerInputSystem.Player.Movement.performed += OnMovementInput;
    }

    private void Update()
    {
        SetMovement();
        SetCameraRotation();
    }

    private void SetMovement()
    {
        characterController.Move(playerMovement * playerVelocity * Time.deltaTime);
    }

    private void SetCameraRotation()
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);

        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 centerPosition = hit.point;

            Vector3 direction = centerPosition - Camera.main.transform.position;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Camera.main.transform.rotation = targetRotation;
            }
        }

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        playerMovementInput = context.ReadValue<Vector2>();
        playerMovement = new Vector3(playerMovementInput.x, 0f, playerMovementInput.y);

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        playerMovement = Quaternion.LookRotation(cameraForward) * playerMovement;
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
