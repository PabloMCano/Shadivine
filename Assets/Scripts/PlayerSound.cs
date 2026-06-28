using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSound : MonoBehaviour
{
    public AudioSource AudioSrce;
    public AudioClip FirstStep;
    public AudioClip SecondStep;
    public AudioClip AttackM1_Sound;
    public AudioClip AttackM2_Sound;
    [SerializeField] private PlayerMovement _pMovement;
    [SerializeField] private PlayerInteract _pInteract;
    [SerializeField] private PlayerAttack _pAttack;


    private bool _listeningFirstStep;
    private bool _canRetrySound = true;
    private float _walkingStepTime;
    private float _runningStepTime;

    private void Update()
    {
        if (_pMovement.PlayerIsMoving)
        {
            if (!_pMovement.ActivateSprint || _pMovement.ActivateSprint && !_pMovement.CanSprinting)
            {
                _walkingStepTime += Time.deltaTime;
                _runningStepTime = 0;

                if (_walkingStepTime >= 0.5f)
                {
                    _listeningFirstStep = true;
                }

                if (_walkingStepTime >= 0.9f)
                {
                    _walkingStepTime = 0;
                    PlaySecondStep();
                    _canRetrySound = true;
                }

                if (_listeningFirstStep)
                {
                    if (_canRetrySound)
                    {
                        PlayFirstStep();
                        _canRetrySound = false;
                    }
                    return;
                }
            }

            if (_pMovement.ActivateSprint && _pMovement.CanSprinting)
            {
                _runningStepTime += Time.deltaTime;
                _walkingStepTime = 0;

                if (_runningStepTime >= 0.23f)
                {
                    _listeningFirstStep = true;
                }

                if (_runningStepTime >= 0.5f)
                {
                    _runningStepTime = 0;
                    PlaySecondStep();
                    _canRetrySound = true;
                }

                if (_listeningFirstStep)
                {
                    if (_canRetrySound)
                    {
                        PlayFirstStep();
                        _canRetrySound = false;
                    }
                    return;
                }
            }
        }

        else
        {
            _walkingStepTime = 0;
            _runningStepTime = 0;
        }
    }

    public void PlayFirstStep()
    {
        AudioSrce.PlayOneShot(FirstStep);
    }

    public void PlaySecondStep()
    {
        AudioSrce.PlayOneShot(SecondStep);
    }

    public void PlayAttackM1Sound()
    {
        AudioSrce.PlayOneShot(AttackM1_Sound);
    }

    public void PlayAttackM2Sound()
    {
        AudioSrce.PlayOneShot(AttackM2_Sound);
    }
}
