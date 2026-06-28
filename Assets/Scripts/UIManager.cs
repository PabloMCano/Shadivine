using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health _pHealth;
    [SerializeField] private GameObject _holdEText;
    [SerializeField] private GameObject _interactEText;
    [SerializeField] private GameObject _loadCircle;
    [SerializeField] private Image _lifeBar;
    [SerializeField] private Image _redBar;
    [SerializeField] private Image _circleBar;
    [SerializeField] private PlayerInteract _pInteract;
    private float _divisionNumberHealth;
    private float _circleCount;
    private bool _startRedBar;
    public bool CanHoldE;
    public bool CanInteractwithE;
    public bool DamageForHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanHoldE)
        {
            _holdEText.SetActive(true);
            _loadCircle.SetActive(true);
        }

        else
        {
            _holdEText.SetActive(false);
            _loadCircle.SetActive(false);
        }

        if (CanInteractwithE)
        {
            _interactEText.SetActive(true);
        }

        else
        {
            _interactEText.SetActive(false);
        }

        _divisionNumberHealth = _pHealth.CurrentHealth / _pHealth.MaxHealth;

        if (_redBar.fillAmount >= _divisionNumberHealth && _startRedBar)
        {
            _redBar.fillAmount -= Time.deltaTime / 2f;
        }

        if (_redBar.fillAmount <= _divisionNumberHealth)
        {
            _startRedBar = false;
        }

        if (DamageForHealth)
        {
            StartCoroutine(HealthCoroutine());
            DamageForHealth = false;
        }

        if (_pInteract.HoldingE)
        {
            _circleCount += Time.deltaTime;
            _circleBar.fillAmount = _circleCount / _pInteract.HoldTime;

            Debug.Log($"{_circleCount}");
        }

        if (_pInteract.HoldingE == false)
        {
            if (_circleCount >= 0f && _circleBar.fillAmount >= 0f)
            { 
              _circleCount -= Time.deltaTime;
              _circleBar.fillAmount = _circleCount / _pInteract.HoldTime;
            }
        }

    }


    private IEnumerator HealthCoroutine()
    {
        _lifeBar.fillAmount = _divisionNumberHealth;

        yield return new WaitForSeconds(0.5f);

        _startRedBar = true;

    }
}
