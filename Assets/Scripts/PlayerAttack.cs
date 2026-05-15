using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _hitboxAttack;
    [SerializeField] private float _timeToFinishCombo;
    [SerializeField] private float _timeToDoAttack;
    private float _timerToAttack;
    private float _timerToContinueCombo;
    private float _comboNumberAttack = 0;
    private bool _isComboActive;

    private void OnAttackM1(InputValue input)
    {
        Debug.Log("Se presiono M1");

        if (input.isPressed && _timerToAttack >= _timeToDoAttack)
        {
            AttackCombo();
        }
    }

    private void Update()
    {
        _timerToAttack += Time.deltaTime;

        if (_isComboActive)
        {
            _timerToContinueCombo += Time.deltaTime;

            if (_timerToContinueCombo >= _timeToFinishCombo)
            {
                _isComboActive = false;
                _comboNumberAttack = 0;
            }
        }
    }

    private void AttackCombo()
    {
        switch (_comboNumberAttack)
        {
            case 0f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _isComboActive = true;

                _timerToAttack = _timeToDoAttack - 0.5f;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 1f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _timerToAttack = _timeToDoAttack - 0.5f;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 2f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _timerToAttack = _timeToDoAttack - 0.5f;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 3f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _timerToAttack = _timeToDoAttack - 0.5f;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 4f:

                StartCoroutine(AttackHitboxPlayerCouroutine());

                _timerToContinueCombo = 0;

                _timerToAttack = 0;
                _comboNumberAttack = 0;
                _isComboActive = false;

                break;
        }
    }

    private IEnumerator AttackHitboxPlayerCouroutine()
    {
        _hitboxAttack.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        _hitboxAttack.SetActive(false);
    }

}
