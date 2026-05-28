using System;
using System.Collections;
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

    private Health _playerHealth;
    private bool _dodging;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _playerHealth = GetComponent<Health>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _actualStaminaDodge = _maxStaminaDodge;
    }

    // Update is called once per frame
    void Update()
    {
        _actualSpeed = _walkingSpeed;

        _timeToRetryDodge += Time.deltaTime;

        if (_actualStaminaDodge < _maxStaminaDodge)
        {
            _actualStaminaDodge += Time.deltaTime * 5;
        }

        if (_activateSprint & _moveInputValue.y > 0.1)
        {
            _actualSpeed = _runSpeed;
        }

        CameraMovement();

        if (_activateDodge)
        {
            if (!_dodging)
            { 
                StartCoroutine(DodgeFunction());
            }
        }
        else 
        {
            Vector3 move = transform.right * _moveInputValue.x + transform.forward * _moveInputValue.y;
            _movement = move * _actualSpeed * Time.deltaTime;

            _cc.Move(_movement);
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
        Debug.Log("Se trató de dodgear");
        if (_timeToRetryDodge > 1.5f && _actualStaminaDodge > _minStamToDoDodge)
        {
            _activateDodge = true;
            _timeToRetryDodge = 0f;
            _actualStaminaDodge -= _minStamToDoDodge;
        }
    }

    private IEnumerator DodgeFunction()
    {
        _dodging = true;
        //Volvemos invencible al jugador
        _playerHealth.SetInvincible(true);
        
        //Lo movemos en la direccion de movimiento
        //Desactivamos la invencibilidad del jugador


        yield return new WaitForSeconds(1);

        //Tenemos que tener guardada la última dirección de movimiento apretada por el jugador (o la actual, si es que está tocando un input ahora).
        //Mover el personaje en el sentido de la ultima dirección de movimiento 

        Debug.Log("DODGE");

        _playerHealth.SetInvincible(false);
        _activateDodge = false;
        _dodging = false;
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
