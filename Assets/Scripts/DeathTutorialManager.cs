using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _textTip;
    [SerializeField] private GameObject _textRetry;
    [SerializeField] private bool _retryFinishLevel;
    private bool _canRetry;
    private float _count;

    // Update is called once per frame
    void Update()
    {
        _count += Time.deltaTime;

        if (_count >= 0.7f)
        {
            _textTip.SetActive(true);
        }

        if (_count >= 2f)
        {
            _textRetry.SetActive(true);
            _canRetry = true;
        }
    }

    private void OnResetLevel()
    {
        if (_canRetry)
        {
            if (_retryFinishLevel)
            {
                SceneManager.LoadScene("Finish Tutorial");
            }
            else
            {
                SceneManager.LoadScene("Reset Corridor");
            }
        }
    }
}
