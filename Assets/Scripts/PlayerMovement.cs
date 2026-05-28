using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _maxStaminaDodge;
    [SerializeField] private float _minStamToDoDodge;
    private CharacterController _cc;
    private Vector2 _moveInputValue;
    private Vector2 _lookInputValue;
    private Vector3 _movement;
    private float _actualSpeed;
    private float _actualStaminaDodge;
    private float _timeToRetryDodge;
    private bool _activateDodge;
    float _xRotation = 0f;
    bool _activateSprint;

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
        _actualSpeed = _walkingSpeed;

        _timeToRetryDodge += Time.deltaTime;

        if (_activateSprint & _moveInputValue.y > 0.1)
        {
            _actualSpeed = _runSpeed;
        }

        Vector3 move = transform.right * _moveInputValue.x + transform.forward * _moveInputValue.y;
        _movement = move * _actualSpeed * Time.deltaTime;

        _cc.Move(_movement);


        CameraMovement();

        if (_activateDodge)
        {

            DodgeFunction();
        }
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

    private void OnSprint(InputValue input)
    {
       if (input.isPressed)
       {
            if (!_activateSprint)
            {
                _activateSprint = true;
            }
            else
            {
                _activateSprint = false;
            }

       }
    }

    private void OnDodge(InputValue input)
    {
        if (_timeToRetryDodge > 1.5f && _actualStaminaDodge > _minStamToDoDodge)
        {
            _activateDodge = true;
            _timeToRetryDodge = 0f;
            _actualStaminaDodge -= _minStamToDoDodge;
        }
    }

    private void DodgeFunction()
    {
       
    }

    private void CameraMovement()
    {
        float mouseX = _lookInputValue.x * _cameraSpeed * Time.deltaTime;
        float mouseY = _lookInputValue.y * _cameraSpeed * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -20f, 45f);

        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX); //Rota el personaje segun la rotacion de la camara 
    }
}
