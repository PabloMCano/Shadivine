using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public GameObject ImageNote;
    public bool ImageOn;

    public void Interact()
    {
        if (!ImageOn)
        {
            ImageOn = true;
            ImageNote.SetActive(true);
        }

        else
        {
            ImageOn = false;
            ImageNote.SetActive(false);
        }
    }
}
