using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _doorPass1;
    [SerializeField] private GameObject _redAlarms;
    [SerializeField] private GameObject _normalLights;
    [SerializeField] private AlarmRedSound _redAlarmsSound;
    private string _actualSceneName;
    public int EnemyDeathCount;
    private float _alarmCount;

    private void Awake()
    {
        _actualSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        _redAlarmsSound.PlayAlarmRedAudio();
    }

    private void Update()
    {
        _alarmCount += Time.deltaTime;

        if (_alarmCount >= 1.2)
        {
            _redAlarms.SetActive(false);
            _normalLights.SetActive(true);
        }

        if (_alarmCount >= 2)
        {
            _redAlarmsSound.PlayAlarmRedAudio();

            _redAlarms.SetActive(true);
            _normalLights.SetActive(false);
            _alarmCount = 0;
        }

    }

    private void OnEnemyDeath()
    {
        EnemyDeathCount++;

        Debug.Log($"{EnemyDeathCount}");

        if (_actualSceneName == "2 Tutorial Corridor" || _actualSceneName == "Reset Corridor")
        {
            if (EnemyDeathCount >= 1)
            {
                ActivateDoorPass();
            }
        }

        if (_actualSceneName == "Finish Tutorial")
        {
            if (EnemyDeathCount >= 7)
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
