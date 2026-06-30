using UnityEngine;

public class AutomaticKilling : MonoBehaviour
{
    [SerializeField] private Health _pHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pHealth.TakeDamage(100000000);
        }
    }
}
