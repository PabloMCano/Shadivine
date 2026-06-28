using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private Animator _animatorP;
    [SerializeField] private UIManager _uiM;
    private PlayerAttack _pAttackScript;
    private PlayerInteract _pInteractScript;
    public float CurrentHealth;
    private bool _isInvincible;
    public bool StopPlayer;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _pAttackScript = GetComponent<PlayerAttack>();
        _pInteractScript = GetComponent<PlayerInteract>();
    }

    public void TakeDamage(int Damage)
    {
    //    if (_isInvincible) return;

        CurrentHealth -= Damage;

        _uiM.DamageForHealth = true;

        StartCoroutine(ToStopPlayer());

        Debug.Log($"El personaje recibió {Damage} de daño, ahora tiene {CurrentHealth} de vida");

        if ( CurrentHealth <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        if (CurrentHealth <= 0)
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

        _animatorP.enabled = false;

        yield return new WaitForSeconds(1);

        _pAttackScript.enabled = true;

        _pInteractScript.enabled = true;

        _animatorP.enabled = true;

        StopPlayer = false;
    }
}
