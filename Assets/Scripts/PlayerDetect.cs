using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _enemy4;
    [SerializeField] private GameObject _enemy5;
    [SerializeField] private UIManager _uiM;
    [SerializeField] private LevelManager _lvlManager;
    private EnemyChase _enemyChase1;
    private EnemyChase _enemyChase2;
    private EnemyChase _enemyChase3;
    private EnemyChase _enemyChase4;
    private EnemyChase _enemyChase5;
    private bool _collisionPlayer;
    private string LevelName;

    private void Awake()
    {
        LevelName = SceneManager.GetActiveScene().name;


        if (_enemy1 != null)
        {
            _enemyChase1 = _enemy1.GetComponent<EnemyChase>();
        }

        else
        {
            return;
        }

        if (_enemy2 != null)
        {
            _enemyChase2 = _enemy2.GetComponent<EnemyChase>();
        }

        else
        {
            return;
        }

        if (_enemy3 != null)
        {
            _enemyChase3 = _enemy3.GetComponent<EnemyChase>();
        }

        else
        {
            return;
        }

        if (_enemy4 != null)
        {
            _enemyChase4 = _enemy4.GetComponent<EnemyChase>();
        }

        else
        {
            return;
        }

        if (_enemy5 != null)
        {
            _enemyChase5 = _enemy5.GetComponent<EnemyChase>();
        }

        else
        {
            return;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject Player = other.gameObject;
            _collisionPlayer = true;

            if (LevelName == "2 Tutorial Corridor" || LevelName == "Reset Corridor")
            {
                if (_lvlManager.EnemyDeathCount >= 1)
                {
                    Destroy(gameObject);
                }

                else
                {
                    StartCoroutine(SceneCoroutine());
                }
            }

            else
            {
                if (_enemyChase1.ObjectToChase == null && _enemyChase1 != null)
                {
                    _enemyChase1.ObjectToChase = Player.transform;
                }

                else
                {
                    return;
                }

                if (_enemyChase2.ObjectToChase == null && _enemyChase2 != null)
                {
                    _enemyChase2.ObjectToChase = Player.transform;
                }

                else
                {
                    return;
                }

                if (_enemyChase3.ObjectToChase == null && _enemyChase3 != null)
                {
                    _enemyChase3.ObjectToChase = Player.transform;
                }

                else
                {
                    return;
                }

                if (_enemyChase4.ObjectToChase == null && _enemyChase4 != null)
                {
                    _enemyChase4.ObjectToChase = Player.transform;
                }

                else
                {
                    return;
                }

                if (_enemyChase5.ObjectToChase == null && _enemyChase5 != null)
                {
                    _enemyChase5.ObjectToChase = Player.transform;
                }

                else
                {
                    return;
                }
            }
        }

        else
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_collisionPlayer && LevelName == "Finish Tutorial")
        {
            Destroy(gameObject);
        }   
    }

    private IEnumerator SceneCoroutine()
    {
        _uiM.BlackScreen.SetActive(true);

        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene("Error Tutorial");
        Debug.Log("Debe cargarse la otra escena");
    }
}
