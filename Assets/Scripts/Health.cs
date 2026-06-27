using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private PlayerAttack _pAttackScript;
    private PlayerInteract _pInteractScript;
    private int _currentHealth;
    private bool _isInvincible;
    public bool StopPlayer;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _pAttackScript = GetComponent<PlayerAttack>();
        _pInteractScript = GetComponent<PlayerInteract>();
    }

    public void TakeDamage(int Damage)
    {
    //    if (_isInvincible) return;

        _currentHealth -= Damage;

        StartCoroutine(ToStopPlayer());

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
            if (SceneManager.GetActiveScene().name == "2 Tutorial Corridor")
            {
                SceneManager.LoadScene("Reset Corridor");
            }

            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    /* public void SetInvincible(bool isInvincible)
      { 
          _isInvincible = isInvincible;
      }
    */

    private IEnumerator ToStopPlayer()
    {
        StopPlayer = true;

        _pAttackScript.enabled = false;

        _pInteractScript.enabled = false;

        yield return new WaitForSeconds(1);

        _pAttackScript.enabled = true;

        _pInteractScript.enabled = true;

        StopPlayer = false;
    }
}
