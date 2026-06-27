using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxEnemyHealth;
    private int _currentEnemyHealth;
    public bool StopAttackEnemy;
    public static event Action OnEnemyDeath;

    private void Awake()
    {
        _currentEnemyHealth = _maxEnemyHealth;
    }

    public void EnemyTakeDamage(int Damage)
    {
        _currentEnemyHealth -= Damage;

        StartCoroutine(ToStopEnemy());

        Debug.Log($"El enemigo recibió {Damage} de daño, ahora tiene {_currentEnemyHealth} de vida");

        if (_currentEnemyHealth <= 0)
        {
            Die(gameObject);
        }
    }

    public void Die(GameObject _gameObject)
    {
        if (_currentEnemyHealth <= 0)
        {
            Debug.Log("El enemigo debe morir");

            OnEnemyDeath?.Invoke();

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
