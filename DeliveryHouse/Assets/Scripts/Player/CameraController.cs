using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private float _smoothing = 1.5f;

    private Vector2 velocityFrame, velocityRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        SetCameraRotation();
    }

    private void SetCameraRotation()
    {
        Vector2 mouseInputs = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawVelocityFrame = Vector2.Scale(mouseInputs, Vector2.one * _sensitivity);
        velocityFrame = Vector2.Lerp(velocityFrame, rawVelocityFrame, 1 / _smoothing);
        velocityRotation += velocityFrame;
        velocityRotation.y = Mathf.Clamp(velocityRotation.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-velocityRotation.y, Vector3.right);
        _playerTransform.localRotation = Quaternion.AngleAxis(velocityRotation.x, Vector3.up);
    }
}
