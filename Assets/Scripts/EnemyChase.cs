using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform _objectToChase;
    [SerializeField] private GameObject _attackObject;
    private EnemyHealth _enHealth;
    private NavMeshAgent _agent;
    private float _agentSpeed;
    private bool _returnToNormalSpeed;

    private void Awake()
    {   
        _agent = GetComponent<NavMeshAgent>();
        _agentSpeed += _agent.speed;
        _enHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        _agent.SetDestination(_objectToChase.position);

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
                _returnToNormalSpeed = false;

                Attack();
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

        yield return new WaitForSeconds(1);

        if (!_enHealth.StopAttackEnemy)
        {
            _attackObject.SetActive(true);
        }

        yield return new WaitForSeconds(1);

        _attackObject.SetActive(false);
        _returnToNormalSpeed = true;

        Debug.Log("Se termino la Corutina");
    }
}
