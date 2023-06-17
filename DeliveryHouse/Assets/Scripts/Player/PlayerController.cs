using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementController _playerMovementController;
    private CameraController _cameraController;
    private PlayerInputSystem _playerInputSystem;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _cameraController = GetComponent<CameraController>();
        _playerInputSystem = new PlayerInputSystem();
    }

    private void Update()
    {

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
