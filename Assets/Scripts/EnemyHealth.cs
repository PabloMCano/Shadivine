using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxEnemyHealth;
    public float CurrentEnemyHealth;
    [SerializeField] private EnemyUIController _enemyUIC;
    [SerializeField] private GameObject _enemyCorpse;
    public bool StopAttackEnemy;
    public static event Action OnEnemyDeath;

    private void Awake()
    {
        CurrentEnemyHealth = MaxEnemyHealth;
    }

    public void EnemyTakeDamage(int Damage)
    {
        CurrentEnemyHealth -= Damage;

        _enemyUIC.DamageAnEnemy = true;

        StartCoroutine(ToStopEnemy());

        Debug.Log($"El enemigo recibió {Damage} de daño, ahora tiene {CurrentEnemyHealth} de vida");

        if (CurrentEnemyHealth <= 0)
        {
            Die(gameObject);
        }
    }

    public void Die(GameObject _gameObject)
    {
        if (CurrentEnemyHealth <= 0)
        {
            Debug.Log("El enemigo debe morir");

            OnEnemyDeath?.Invoke();

            Instantiate(_enemyCorpse, transform.position, transform.rotation);

            Destroy(_gameObject);
        }
    }

    
    private IEnumerator ToStopEnemy()
    {
        StopAttackEnemy = true;
        yield return new WaitForSeconds(0.5f);
        StopAttackEnemy = false;
    }

    
}
