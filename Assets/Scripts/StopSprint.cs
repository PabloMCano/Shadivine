using UnityEngine;

public class StopSprint : MonoBehaviour
{
    [SerializeField] private PlayerMovement _pMovement;

    private void Update()
    {
        _pMovement.StopRun = true;
    }
    private void OnDestroy()
    {
        _pMovement.StopRun = false;
    }
}
