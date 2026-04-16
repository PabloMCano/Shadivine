using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hola, soy una nota");
    }
}
