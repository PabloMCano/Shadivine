using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private UIManager _uiM;
    [SerializeField] private Note _note;
    [SerializeField] private PassToNextLevel _csToNextLevel;
    public float HoldTime;
    public bool HoldingE;
    private float _timerHold;
    private string _tagInteractable;
    private IInteractable _interactable;
    private RaycastHit _hitRaycast;

    private void Awake()
    {
        _tagInteractable = "InteractableTag";
    }

    void Update()
    {
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * distance, Color.red);

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _hitRaycast, distance))
        {
            // Debug.Log("Le pegaste a: " + _hitRaycast.collider.name);

            _interactable = _hitRaycast.collider.GetComponentInParent<IInteractable>();

            if (_hitRaycast.collider.tag == _tagInteractable)
            {
                _uiM.CanInteractwithE = true;
            }
            else
            {
                _uiM.CanInteractwithE = false;
                // Debug.Log("NO tiene IInteractable");
            }
        }

        if (HoldingE)
        {
            _timerHold += Time.deltaTime;
        }

        else
        {
            _timerHold = 0;
        }
    }

    void TryInteract()
    {
        if (_interactable != null && _hitRaycast.collider.CompareTag("InteractableTag"))
        {
            _interactable.Interact();

            if (_uiM.InteractEText)
            {
                _uiM.InteractEText.SetActive(false);
            }
        }

        else
        {
            return;
        }
    }

    // ESTE método lo llama el PlayerInput automáticamente
    private void OnInteract(InputValue value)
    {
        if (_note.ImageOn)
        {
            _note.ImageNote.SetActive(false);
            _note.ImageOn = false;
            _note.PlayNoteClose();
        }

        else
        {
            TryInteract();
        }
    }

    private void OnLongInteract(InputValue value)
    {
        if (_csToNextLevel.PlayerCanInteract)
        {
            HoldingE = value.isPressed;
        }

        else
        {
            HoldingE = false;
        }

        if (_csToNextLevel != null && _timerHold >= HoldTime || _csToNextLevel != null && _uiM.FullLoading)
        {
            if (_csToNextLevel.PlayerCanInteract)
            {
                _csToNextLevel.ActivatedInteract = true;

                Debug.Log("Se mantuvo apretado y debe de interactuar");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PassToNextLevel>())
        {
            _csToNextLevel = other.GetComponent<PassToNextLevel>();
        }
    }
}