using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxEnemyHealth;
    private int _currentEnemyHealth;
    public bool StopAttackEnemy;

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
            Die();
        }
    }

    private void Die()
    {
        if (_currentEnemyHealth <= 0)
        {
            Debug.Log("El enemigo debe morir");

            Destroy(gameObject);
        }
    }

    
    private IEnumerator ToStopEnemy()
    {
        StopAttackEnemy = true;
        yield return new WaitForSeconds(0.5f);
        StopAttackEnemy = false;
    }

    
}
