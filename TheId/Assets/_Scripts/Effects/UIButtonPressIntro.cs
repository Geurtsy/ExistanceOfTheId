using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonPressIntro : MonoBehaviour
{
    [SerializeField] private float _revealSpeed;
    [SerializeField] private ParticleSystem _revealParticles;
    [SerializeField] private TrailRenderer _revealTrail;

    [SerializeField] private int _slowFlickerAmount;
    [SerializeField] private float _slowFlickerLength;
    [SerializeField] private int _fastFlickerAmount;
    [SerializeField] private float _fastFlickerLength;
    [SerializeField] private float _onFlickerLength;

    [Range(0, 1)]
    [SerializeField] private float _onFlickerTransparency;
    [SerializeField] private Image _mask;

    [SerializeField] private float _turnOnDuration;

    [SerializeField] private Image[] _powerGlow;
    [SerializeField] private float _breathSpeed;

    private bool _isRunning;

    public void StartOnSequence()
    {
        print(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5)));

        if(!_isRunning)
        {
            StartCoroutine(OnSequence());
            StartCoroutine(ButtonBreath());
            _revealParticles = _revealParticles.GetComponent<ParticleSystem>();

            _isRunning = true;
        }
    }

    private IEnumerator OnSequence()
    {
        //float step = 0.0f;
        while(true)
        {
            var width = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5)).x;
            var currentShape = _revealParticles.shape;

            _mask.rectTransform.Translate(transform.up * Time.deltaTime * _revealSpeed);
            currentShape.radius = width;
            _revealTrail.widthMultiplier = width * Camera.main.orthographicSize;
            yield return null;
        }

        //for(int num = 0; num < _slowFlickerAmount; num++)
        //{
        //    _mask.color = new Color(0.0f, 0.0f, 0.0f, _onFlickerTransparency);
        //    yield return new WaitForSeconds(_onFlickerLength);
        //    _mask.color = new Color(0.0f, 0.0f, 0.0f, 1);
        //    yield return new WaitForSeconds(_slowFlickerLength);
        //}

        //for(int num = 0; num < _fastFlickerAmount; num++)
        //{
        //    _mask.color = new Color(0.0f, 0.0f, 0.0f, _onFlickerTransparency);
        //    yield return new WaitForSeconds(_onFlickerLength);
        //    _mask.color = new Color(0.0f, 0.0f, 0.0f, 1);
        //    yield return new WaitForSeconds(_fastFlickerLength);
        //}

        //while(step < 1)
        //{
        //    _mask.color = Color.Lerp(Color.black, Color.clear, step);
        //    step += Time.deltaTime / _turnOnDuration;
        //    yield return null;
        //}

        //Destroy(_mask);

        //yield return null;
    }

    private IEnumerator ButtonBreath()
    {
        var step = 1.0f;
        var startColour = _powerGlow[0].color;

        var neg = 1;

        while(true)
        {
            step += (Time.deltaTime / _breathSpeed) * neg;

            while(step > 0 && step < 1)
            {
                step += (Time.deltaTime / _breathSpeed) * neg;

                foreach(Image img in _powerGlow)
                {
                    img.color = Color.Lerp(startColour, Color.white, step);
                }

                yield return null;
            }

            neg *= -1;

            yield return null;
        }
    }
}
