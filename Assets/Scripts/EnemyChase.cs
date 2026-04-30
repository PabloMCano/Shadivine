using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform _objectToChase;
    [SerializeField] private GameObject _attackObject;
    private NavMeshAgent _agent;

    private void Awake()
    {   
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_objectToChase.position);

    }

    private void Attack()
    {
        if (_agent.isStopped)
        {
            _attackObject.SetActive(true);
        }
        else
        {
            _attackObject.SetActive(false);
        }
    }

}
