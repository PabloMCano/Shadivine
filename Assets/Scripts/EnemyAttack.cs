using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    void OnCollisionEnter(Collision collision)
    {
        Health HealthComponent = collision.gameObject.GetComponent<Health>();

        if (HealthComponent != null & collision.gameObject.CompareTag("Player"))
        {
            HealthComponent.ReceiveDamage(_damage);
        }
    }
}
