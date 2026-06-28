using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _wasdImage;
    [SerializeField] private PlayerMovement _pMovement;
    [SerializeField] private Animator _wasdAnimator;
    private bool _stopCountMoves;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopCountMoves)
        {
            _pMovement.CountMovesPlayer = 0;
        }

        if (_pMovement.CountMovesPlayer >= 15)
        {
            _stopCountMoves = true;

            StartCoroutine(DisappearWASD());
        }
    }

    private IEnumerator DisappearWASD()
    {
        _wasdAnimator.SetBool("Dissapear", true);

        yield return new WaitForSeconds(1);

        _wasdImage.SetActive(false);
    }
}
