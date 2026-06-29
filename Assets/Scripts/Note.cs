using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public AudioSource NoteAudioSrc;
    public AudioClip NoteOpen;
    public AudioClip NoteClose;
    public GameObject ImageNote;
    public GameObject TheCrosshair;
    public bool ImageOn;

    public void Interact()
    {
        if (!ImageOn)
        {
            ImageOn = true;
            ImageNote.SetActive(true);
            TheCrosshair.SetActive(false);

            PlayNoteOpen();
        }

        else
        {
            ImageOn = false;
            ImageNote.SetActive(false);
            TheCrosshair.SetActive(true);
            PlayNoteClose();
        }
    }

    public void PlayNoteOpen()
    {
        NoteAudioSrc.PlayOneShot(NoteOpen);
    }

    public void PlayNoteClose()
    {
        NoteAudioSrc.PlayOneShot(NoteClose);
    }
}
