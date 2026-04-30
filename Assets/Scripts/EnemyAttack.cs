using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        Health HealthComponent = other.GetComponent<Health>();

        if (HealthComponent != null & other.CompareTag("Player"))
        {
            HealthComponent.TakeDamage(_damage);
        }
    }
}
