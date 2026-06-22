using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class KillBehindInteract : MonoBehaviour
{
    [SerializeField] private GameObject _toDestroy;
    public bool PlayerCanKill;
    public bool EnemyDies;
    private EnemyChase _enemyChaseScript;

    private void Update()
    {
        if (EnemyDies)
        {
            Debug.Log("Debe crearse un cadaver aca");
            Destroy(_toDestroy);
            EnemyDies = false;
        }

        if (_toDestroy.GetComponent<EnemyChase>() != null)
        {
            if (_enemyChaseScript == null)
            {
                _enemyChaseScript = _toDestroy.GetComponent<EnemyChase>();
            }

            else
            {
                if (_enemyChaseScript.ObjectToChase != null)
                {
                    Destroy(gameObject);
                }

                else
                {
                    return;
                }
            }
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
