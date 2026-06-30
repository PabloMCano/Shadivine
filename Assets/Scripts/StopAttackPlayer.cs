using UnityEngine;

public class StopAttackPlayer : MonoBehaviour
{
    [SerializeField] private PlayerAttack _pAttack;

    // Update is called once per frame
    void Update()
    {
        _pAttack.StopAttackTimer();
    }
}
