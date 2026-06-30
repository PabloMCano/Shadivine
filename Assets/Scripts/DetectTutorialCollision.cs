using UnityEngine;

public class DetectTutorialCollision : MonoBehaviour
{
    [SerializeField] private TutorialManager _tutoManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.tag == "SprintTutorialTag")
        {
            _tutoManager.OnSprintTutorial = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && this.tag == "KillBehindTutorialTag")
        {
            _tutoManager.KillBehindTutorial = true;
            Destroy(gameObject);
        }
    }
}
