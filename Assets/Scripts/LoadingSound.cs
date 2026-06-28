using UnityEngine;

public class LoadingSound : MonoBehaviour
{
    [SerializeField] private PlayerInteract _pInteract;
    private bool _playingLoadingSound;
    private bool _canPlayLoadingSound = true;

    public AudioSource LoadAudioSrce;
    public AudioClip Loading_Sound;


    // Update is called once per frame
    void Update()
    {
        if (_pInteract.HoldingE)
        {
            _playingLoadingSound = true;
        }

        else
        {
            LoadAudioSrce.Stop();

            _playingLoadingSound = false;
            _canPlayLoadingSound = true;
        }


        if (_playingLoadingSound)
        {
            if (_canPlayLoadingSound)
            {
                PlayLoadingSound();
                _canPlayLoadingSound = false;
            }
            return;
        }
    }

    public void PlayLoadingSound()
    {
        LoadAudioSrce.clip = Loading_Sound;
        LoadAudioSrce.Play();
    }

}
