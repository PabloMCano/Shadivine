using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform ObjectToChase;
    [SerializeField] private GameObject _attackObject;
    [SerializeField] private Animator _animatorEnemy;
    private EnemyHealth _enHealth;
    private NavMeshAgent _agent;
    private float _agentSpeed;
    private bool _returnToNormalSpeed = true;

    private void Awake()
    {   
        _agent = GetComponent<NavMeshAgent>();
        _agentSpeed += _agent.speed;
        _enHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (ObjectToChase != null)
        {
            _agent.SetDestination(ObjectToChase.position);
        }

        if (_enHealth.StopAttackEnemy)
        {
            _agent.speed = 0;
        }

        else
        {
            if (_returnToNormalSpeed)
            {
                _agent.speed = _agentSpeed;
            }

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && _agent.speed != 0)
            {
                if (ObjectToChase != null)
                {
                    _returnToNormalSpeed = false;

                    Attack();
                }

                else
                {
                    return;
                }
            }
        }
    }

    private void Attack()
    {
        StartCoroutine(AttackCouroutine());
    }


    private IEnumerator AttackCouroutine()
    {
        Debug.Log("Se inicio la Courutina");

        _agent.speed = 0;

        _animatorEnemy.SetBool("OnAttack", true);

        yield return new WaitForSeconds(0.5f);

        if (!_enHealth.StopAttackEnemy)
        {
            _attackObject.SetActive(true);
        }

        else
        {
            _animatorEnemy.SetBool("OnAttack", false);
        }

        yield return new WaitForSeconds(0.5f);

        _attackObject.SetActive(false);
        _animatorEnemy.SetBool("OnAttack", false);
        _returnToNormalSpeed = true;

        Debug.Log("Se termino la Corutina");
    }
}
