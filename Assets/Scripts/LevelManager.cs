using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _enemyDeathCount;

    private void OnEnemyDeath()
    {
        _enemyDeathCount++;

        Debug.Log($"{_enemyDeathCount}");
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeath -= OnEnemyDeath;
    }
}
