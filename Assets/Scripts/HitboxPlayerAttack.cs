using UnityEngine;
using UnityEngine.InputSystem;

public class HitboxPlayerAttack : MonoBehaviour
{
    private int _damage;

    public void ChangesDamage(int Damage)
    {
        _damage = Damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisiono con algo");

        EnemyHealth HealthEnemyComponent = other.GetComponent<EnemyHealth>();

        if (HealthEnemyComponent != null & other.CompareTag("Enemy"))
        {
            Debug.Log("Colisiono con el enemigo");

            HealthEnemyComponent.EnemyTakeDamage(_damage);
        }
    }

}
