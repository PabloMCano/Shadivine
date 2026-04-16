using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _cc;
    private Vector2 _moveInputValue;
    private Vector2 _lookInputValue;
    private Vector3 _movement;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private float _cameraSpeed;
    float _xRotation = 0f;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * _moveInputValue.x + transform.forward * _moveInputValue.y;
        _movement = move * _moveSpeed * Time.deltaTime;

        _cc.Move(_movement);


        CameraMovement();
    }

    private void OnMove(InputValue input)
    {
        _moveInputValue = input.Get<Vector2>();
    }

    private void OnLook(InputValue input)
    {
        _lookInputValue = input.Get<Vector2>();

      //Debug.Log($"El mouse se movió {_lookInputValue}");
    }

    private void CameraMovement()
    {
        float mouseX = _lookInputValue.x * _cameraSpeed * Time.deltaTime;
        float mouseY = _lookInputValue.y * _cameraSpeed * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX); //Rota el personaje segun la rotacion de la camara 
    }
}
