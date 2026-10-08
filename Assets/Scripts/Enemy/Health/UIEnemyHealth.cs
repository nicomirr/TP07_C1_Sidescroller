using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealth : MonoBehaviour
{
    [SerializeField] private Image _fillImage;

    private CanvasGroup _canvasGroup;
    
    private Coroutine _displayHealthRoutine;


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _fillImage.fillAmount = 1;
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        _fillImage.fillAmount = currentHealth / maxHealth;

        if (_displayHealthRoutine != null)
        {
            StopCoroutine(_displayHealthRoutine);
            _displayHealthRoutine = null;
        }

        _displayHealthRoutine = StartCoroutine(DisplayHealthUI());
    }

    private IEnumerator DisplayHealthUI()
    {
        _canvasGroup.alpha = 1;

        yield return new WaitForSeconds(1);

        _canvasGroup.alpha = 0;
    }
}
