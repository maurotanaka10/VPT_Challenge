using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementController playerMovementController;
    private CameraController cameraController;
    private PlayerInputSystem playerInputSystem;
    private ActionPlayerController actionPlayerController;

    private void Awake()
    {
        playerMovementController = GetComponent<PlayerMovementController>();
        cameraController = GetComponent<CameraController>();
        playerInputSystem = new PlayerInputSystem();
        actionPlayerController = GetComponent<ActionPlayerController>();
    }

    private void Update()
    {

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
