using UnityEngine;

public class AlarmRedSound : MonoBehaviour
{
    public AudioSource AlarmAudioSrce;
    public AudioClip AlarmRedAudio;

    public void PlayAlarmRedAudio()
    {
        AlarmAudioSrce.PlayOneShot(AlarmRedAudio);
    }
}
