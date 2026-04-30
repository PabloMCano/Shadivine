using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform _objectToChase;
    private NavMeshAgent _agent;

    private void Awake()
    {   
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_objectToChase.position);
    }

}
