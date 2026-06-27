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
    [SerializeField] private int _M1Damage;
    [SerializeField] private int _M2Damage;
    [SerializeField] private GameObject _katana;
    [SerializeField] private Animator _characterAnimations;
    [SerializeField] private GameObject _particlesForAttack;
    private HitboxPlayerAttack _hitboxDamage;
    private float _timerToAttack;
    private float _timerToContinueCombo;
    private float _comboNumberAttack = 0;
    private bool _isComboActive;

    private KillBehindInteract _killbehind;

    private void Awake()
    {
        _hitboxDamage = _hitboxAttack.GetComponent<HitboxPlayerAttack>();
    }

    private void OnAttackM1(InputValue input)
    {     
        _hitboxDamage.ChangesDamage(_M1Damage);

        if (_timerToAttack >= _timeToDoAttack)
        {
            AttackCombo(0.5f);
        }
    }

    private void OnAttackM2(InputValue input)
    {

        _hitboxDamage.ChangesDamage(_M2Damage);

        if (_timerToAttack >= _timeToDoAttack)
        {
            AttackCombo(1f);
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

    private void AttackCombo(float secondsForOtherAttack)
    {
        switch (_comboNumberAttack)
        {
            case 0f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _isComboActive = true;

                _timerToAttack = _timeToDoAttack - secondsForOtherAttack;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 1f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _timerToAttack = _timeToDoAttack - secondsForOtherAttack;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 2f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _timerToAttack = _timeToDoAttack - secondsForOtherAttack;

                StartCoroutine(AttackHitboxPlayerCouroutine());

                break;

            case 3f:
                _comboNumberAttack++;
                _timerToContinueCombo = 0;

                _timerToAttack = _timeToDoAttack - secondsForOtherAttack;

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

        _katana.gameObject.SetActive(true);
        _characterAnimations.SetBool("OnAttack", true);
        _particlesForAttack.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        _hitboxAttack.SetActive(false);

        _katana.gameObject.SetActive(false);
        _characterAnimations.SetBool("OnAttack", false);
        _particlesForAttack.gameObject.SetActive(false);
    }

    private void OnInstaKill(InputValue value)
    {
        if (_killbehind != null)
        {
            if (_killbehind.PlayerCanKill)
            {
                _killbehind.EnemyDies = true;

                Debug.Log("Se Toco y puede matar");
            }
        }
            Debug.Log("Se toco");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<KillBehindInteract>())
        {
           _killbehind = other.GetComponent<KillBehindInteract>();
        }
    }
}
