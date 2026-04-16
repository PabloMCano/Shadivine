using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactableLayer;

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
}