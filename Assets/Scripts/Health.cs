using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int Damage)
    {
        _currentHealth -= Damage;

        Debug.Log($"El personaje recibió {Damage} de daño, ahora tiene {_currentHealth} de vida");

        if ( _currentHealth <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene("Test_Map");
        }
    }
}
