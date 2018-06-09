using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonPressIntro : MonoBehaviour
{
    [SerializeField] private int _slowFlickerAmount;
    [SerializeField] private float _slowFlickerLength;
    [SerializeField] private int _fastFlickerAmount;
    [SerializeField] private float _fastFlickerLength;
    [SerializeField] private float _onFlickerLength;

    [Range(0, 1)]
    [SerializeField] private float _onFlickerTransparency;
    [SerializeField] private Image _mask;

    [SerializeField] private float _turnOnDuration;

    public void StartOnSequence()
    {
        StartCoroutine(OnSequence());
    }

    private IEnumerator OnSequence()
    {
        float step = 0.0f;

        for(int num = 0; num < _slowFlickerAmount; num++)
        {
            _mask.color = new Color(0.0f, 0.0f, 0.0f, _onFlickerTransparency);
            yield return new WaitForSeconds(_onFlickerLength);
            _mask.color = new Color(0.0f, 0.0f, 0.0f, 1);
            yield return new WaitForSeconds(_slowFlickerLength);
        }

        for(int num = 0; num < _fastFlickerAmount; num++)
        {
            _mask.color = new Color(0.0f, 0.0f, 0.0f, _onFlickerTransparency);
            yield return new WaitForSeconds(_onFlickerLength);
            _mask.color = new Color(0.0f, 0.0f, 0.0f, 1);
            yield return new WaitForSeconds(_fastFlickerLength);
        }

        while(step < 1)
        {
            _mask.color = Color.Lerp(Color.black, Color.clear, step);
            step += Time.deltaTime / _turnOnDuration;
            yield return null;
        }

        Destroy(_mask);
        yield return null;
    }

}
