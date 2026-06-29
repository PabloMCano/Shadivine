using UnityEngine;

public class ButtonDoor : MonoBehaviour, IInteractable
{
    public AudioSource ButtonAudioSrce;
    public AudioClip ButtonError;
    private float _countToRetryButton;

    public void Interact()
    {
        if (_countToRetryButton >= 1)
        {
            _countToRetryButton = 0;
            PlayButtonErrorSound();
        }

        else
        {
            return;
        }
    }

    private void Update()
    {
        _countToRetryButton += Time.deltaTime;

        if (_countToRetryButton <= 1)
        {
            this.tag = "Untagged";
        }

        if (_countToRetryButton >= 1)
        {
            this.tag = "InteractableTag";
        }
    }

    public void PlayButtonErrorSound()
    {
        ButtonAudioSrce.PlayOneShot(ButtonError);
    }
}
