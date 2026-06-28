using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public AudioSource NoteAudioSrc;
    public AudioClip NoteOpen;
    public AudioClip NoteClose;
    public GameObject ImageNote;
    public bool ImageOn;

    public void Interact()
    {
        if (!ImageOn)
        {
            ImageOn = true;
            ImageNote.SetActive(true);

            PlayNoteOpen();
        }

        else
        {
            ImageOn = false;
            ImageNote.SetActive(false);
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
