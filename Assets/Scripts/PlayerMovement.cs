using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _cc;
    private PlayerInput _pInput;
    private Vector2 _inputValue;
    private Vector3 _movement;
    [SerializeField] private int _speed;


    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _pInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * _inputValue.x + transform.forward * _inputValue.y;
        _movement = move * _speed * Time.deltaTime;

        _cc.Move(_movement);
    }

    private void OnMove(InputValue input)
    {
        _inputValue = input.Get<Vector2>();
    }
}
