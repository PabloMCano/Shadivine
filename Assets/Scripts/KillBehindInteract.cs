using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class KillBehindInteract : MonoBehaviour
{
    [SerializeField] private GameObject _toDestroy;
    public bool PlayerCanKill;
    public bool EnemyDies;
    private EnemyChase _enemyChaseScript;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private UIManager _uiM;

    public AudioSource KillBehindAudioSrc;
    public AudioClip NeckBreaker;

    private void Update()
    {
        if (EnemyDies)
        {
            StartCoroutine(BlackScreenForKilling());

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

    private IEnumerator BlackScreenForKilling()
    {
        _uiM.BlackScreen.SetActive(true);

        yield return new WaitForSeconds(0.6f);

        PlayNeckBreaker();

        yield return new WaitForSeconds(0.5f);

        _uiM.BlackScreenAnimator.SetBool("DisappearBool", true);
        _enemyHealth.EnemyTakeDamage(500000000);

        yield return new WaitForSeconds(0.4f);

        _uiM.BlackScreenAnimator.SetBool("DisappearBool", false);
        _uiM.BlackScreen.SetActive(false);
    }

    private void PlayNeckBreaker()
    {
        KillBehindAudioSrc.PlayOneShot(NeckBreaker);
    }

}
