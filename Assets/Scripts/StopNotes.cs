using UnityEngine;

public class StopNotes : MonoBehaviour
{
    [SerializeField] private Note _note;
    [SerializeField] private UIManager _uiM;

    private void OnTriggerExit(Collider other)
    {
        _note.ImageOn = false;
        _note.ImageNote.SetActive(false);
        _uiM.CloseEText.SetActive(false);
    }
}
