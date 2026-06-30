using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _wasdImage;
    [SerializeField] private GameObject _sprintTutorialImage;
    [SerializeField] private GameObject _killBehindTutorialImage;
    [SerializeField] private PlayerMovement _pMovement;
    [SerializeField] private Animator _wasdAnimator;
    [SerializeField] private PlayerInput _pInput;
    [SerializeField] private PlayerInput _uiInput;
    [SerializeField] private GameObject _buttonContinue;
    [SerializeField] private StopSprint _stopSprint;
    private bool _activeTimerButton;
    private float _timerButton;
    public bool KillBehindTutorial;
    public bool OnSprintTutorial;
    private bool _stopCountMoves;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_wasdImage != null && _wasdAnimator != null)
        {
            if (_stopCountMoves)
            {
                _pMovement.CountMovesPlayer = 0;
            }

            if (_pMovement.CountMovesPlayer >= 15)
            {
                _stopCountMoves = true;

                StartCoroutine(DisappearWASD());
            }
        }

        if (OnSprintTutorial)
        {
            _sprintTutorialImage.SetActive(true);
            Time.timeScale = 0f;
            _activeTimerButton = true;

            if (_timerButton >= 1)
            {
                _buttonContinue.SetActive(true);
            }
        }

        if (KillBehindTutorial)
        {
                _killBehindTutorialImage.SetActive(true);
                Time.timeScale = 0f;
                _activeTimerButton = true;

                if (_timerButton >= 1)
                {
                    _buttonContinue.SetActive(true);
                }
        }

        if (Time.timeScale == 0f)
        {
            _pInput.enabled = false;
            _uiInput.enabled = true;
        }

        else
        {
            _pInput.enabled = true;
            _uiInput.enabled = false;
        }
        
        if (_activeTimerButton)
        {
            _timerButton += Time.unscaledDeltaTime;
        }
    }

    private IEnumerator DisappearWASD()
    {
        _wasdAnimator.SetBool("Dissapear", true);

        yield return new WaitForSeconds(1);

        _wasdImage.SetActive(false);
    }

    private void OnContinue()
    {
        if (OnSprintTutorial && Time.timeScale == 0f && _buttonContinue.activeInHierarchy)
        {
            OnSprintTutorial = false;
            _sprintTutorialImage.SetActive(false);
            _buttonContinue.SetActive(false);
            _activeTimerButton = false;
            _timerButton = 0f;
            _uiInput.enabled = false;
            Destroy(_stopSprint);
            Time.timeScale = 1f;
        }

        if (KillBehindTutorial && Time.timeScale == 0f && _buttonContinue.activeInHierarchy)
        {
            KillBehindTutorial = false;
            _killBehindTutorialImage.SetActive(false);
            _buttonContinue.SetActive(false);
            _activeTimerButton = false;
            _timerButton = 0f;
            _uiInput.enabled = false;
            Time.timeScale = 1f;
        }
    }
}
