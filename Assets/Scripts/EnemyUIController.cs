using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enHealth;
    [SerializeField] private Image _enemyLifeBar;
    [SerializeField] private Image _enemyRedBar;
    private float _enemyDivisionNumberHealth;
    private bool _enemyStartsRedBar;
    public bool DamageAnEnemy;

    // Update is called once per frame
    void Update()
    {
        _enemyDivisionNumberHealth = _enHealth.CurrentEnemyHealth / _enHealth.MaxEnemyHealth;

        if (_enemyRedBar.fillAmount >= _enemyDivisionNumberHealth && _enemyStartsRedBar)
        {
            _enemyRedBar.fillAmount -= Time.deltaTime / 2f;
        }

        if (_enemyRedBar.fillAmount <= _enemyDivisionNumberHealth)
        {
            _enemyStartsRedBar = false;
        }

        if (DamageAnEnemy)
        {
            StartCoroutine(EnemyHealthCoroutine());
            DamageAnEnemy = false;
        }
    }

    private IEnumerator EnemyHealthCoroutine()
    {
        _enemyLifeBar.fillAmount = _enemyDivisionNumberHealth;

        yield return new WaitForSeconds(0.5f);

        _enemyStartsRedBar = true;

    }
}
