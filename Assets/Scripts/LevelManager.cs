using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _doorPass1;
    [SerializeField] private GameObject _redAlarms;
    [SerializeField] private GameObject _normalLights;
    private string _actualSceneName;
    private int _enemyDeathCount;
    private float _alarmCount;

    private void Awake()
    {
        _actualSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        _alarmCount += Time.deltaTime;

        if (_alarmCount >= 1)
        {
            _redAlarms.SetActive(false);
            _normalLights.SetActive(true);
        }

        if (_alarmCount >= 2)
        {
            _redAlarms.SetActive(true);
            _normalLights.SetActive(false);
            _alarmCount = 0;
        }

    }

    private void OnEnemyDeath()
    {
        _enemyDeathCount++;

        Debug.Log($"{_enemyDeathCount}");

        if (_actualSceneName == "2 Tutorial Corridor" || _actualSceneName == "Reset Corridor")
        {
            if (_enemyDeathCount >= 1)
            {
                ActivateDoorPass();
            }
        }

        if (_actualSceneName == "Finish Tutorial")
        {
            if (_enemyDeathCount >= 7)
            {
                ActivateDoorPass();
            }
        }
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeath -= OnEnemyDeath;
    }

    private void ActivateDoorPass()
    {
        _doorPass1.gameObject.SetActive(true);
    }
}
