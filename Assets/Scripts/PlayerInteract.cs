using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactableLayer;
    private PassToNextLevel _csToNextLevel;

    private bool _buttonInteractPressed;

    void Update()
    {

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * distance, Color.red);

        if (_buttonInteractPressed)
        {
            TryInteract();
            _buttonInteractPressed = false; // reset
        }
    }

    void TryInteract()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, distance, interactableLayer))
        {
            Debug.Log("Le pegaste a: " + hit.collider.name);

            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log("NO tiene IInteractable");
            }
        }
        else
        {
            Debug.Log("No le pegaste a nada");
        }
    }

    // ESTE método lo llama el PlayerInput automáticamente
    private void OnInteract(InputValue value)
    {
       _buttonInteractPressed = true;

    }

    private void OnLongInteract(InputValue value)
    {
        if (_csToNextLevel != null)
        {
            if (_csToNextLevel.PlayerCanInteract)
            {
                _csToNextLevel.ActivatedInteract = true;

                Debug.Log("Se mantuvo apretado y debe de interactuar");
            }
        }
        Debug.Log("Se mantuvo apretado");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PassToNextLevel>())
        {
            _csToNextLevel = other.GetComponent<PassToNextLevel>();
        }
    }
}