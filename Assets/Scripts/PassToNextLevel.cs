using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour
{
    [SerializeField] private string _sceneToPass;
    [SerializeField] private UIManager _uiM;
    public bool ActivatedInteract;
    public bool PlayerCanInteract;

    private void Update()
    {
        if (ActivatedInteract)
        {
            Active();
            ActivatedInteract = false;
        }
    }

    private void Active()
    {
        SceneManager.LoadScene(_sceneToPass);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerInteract>() != null)
        {
           PlayerCanInteract = true;
            _uiM.CanHoldE = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerInteract>() != null)
        {
            PlayerCanInteract = false;
            _uiM.CanHoldE = false;
        }
    }
}
