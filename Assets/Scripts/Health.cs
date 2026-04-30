using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    private void Update()
    {
        ZeroHealth();
    }

    public void ReceiveDamage(int Damage)
    {
        _health -= Damage;

        Debug.Log($"El personaje recibió {Damage} de daño, ahora tiene {_health} de vida");
    }

    private void ZeroHealth()
    {
        if (_health <= 0)
        {
            SceneManager.LoadScene("Test_Map");
        }
    }
}
