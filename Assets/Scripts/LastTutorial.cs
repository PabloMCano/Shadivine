using UnityEngine;
using UnityEngine.InputSystem;

public class LastTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _attackTutorialImage;
    [SerializeField] private PlayerInput _pInput;
    [SerializeField] private PlayerInput _uiInput;
    [SerializeField] private GameObject _buttonContinue;
    private float _timerButton;

    private void Start()
    {
        _attackTutorialImage.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        _timerButton += Time.unscaledDeltaTime;

        if (_timerButton >= 1)
        {
            _buttonContinue.SetActive(true);
        }
    }

    private void OnContinue()
    {
        if (_buttonContinue.activeInHierarchy)
        {
            _attackTutorialImage.SetActive(false);
            _buttonContinue.SetActive(false);
            _uiInput.enabled = false;
            _pInput.enabled = true;
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}
