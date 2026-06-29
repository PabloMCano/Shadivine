using UnityEngine;

public class StopNotes : MonoBehaviour
{
    [SerializeField] private Note _note;
    [SerializeField] private UIManager _uiM;

    private void OnTriggerExit(Collider other)
    {
        if (_note.ImageOn)
        {
            _note.ImageOn = false;
            _note.ImageNote.SetActive(false);
            _note.TheCrosshair.SetActive(true);
            _note.PlayNoteClose();
            _uiM.CloseEText.SetActive(false);
        
        }

        else
        {
            return;
        }
    }
}
