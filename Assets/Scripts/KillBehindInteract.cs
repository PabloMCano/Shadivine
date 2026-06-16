using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class KillBehindInteract : MonoBehaviour
{
    [SerializeField] private GameObject _toDestroy;
    public bool PlayerCanKill;
    public bool EnemyDies;

    private void Update()
    {
        if (EnemyDies)
        {
            Debug.Log("Debe crearse un cadaver aca");
            Destroy(_toDestroy);
            EnemyDies = false;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerAttack>() != null)
        {
            PlayerCanKill = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerAttack>() != null)
        {
            PlayerCanKill = false;
        }
    }

}
