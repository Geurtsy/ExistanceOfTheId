using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeEffect : MonoBehaviour{

    [Header("Fade")]
    [SerializeField] private Image _mask;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private Color _colourEnd;

    [Header("Effects")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _particleStartOnPercentFade;
    [SerializeField] private GameObject _fastEffect;
    [SerializeField] private int _amountOfFastEffects;
    [SerializeField] private GameObject _slowEffect;
    [SerializeField] private float _durationBetweenFastParticles;
    private bool _ready = true;
    private int _currentEffectNum;

    private void Start()
    {
        StartCoroutine(ProduceEffect());
    }

    private IEnumerator ProduceEffect()
    {
        Color beginColour = _mask.color;
        float step = 0.0f;

        while(step < 1.0f)
        {
            step += Time.deltaTime / _fadeDuration;
            _mask.color = Color.Lerp(beginColour, _colourEnd, step);

            if(step > _particleStartOnPercentFade && _ready)
            {
                StartCoroutine(CreateParticleEffect());
            }

            yield return null;
        }


        yield return null;
    }

    private IEnumerator CreateParticleEffect()
    {
        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));


        if(_currentEffectNum < _amountOfFastEffects)
        {
            Instantiate(_fastEffect, randomPositionOnScreen, Quaternion.Euler(0, 0, 0));
            _currentEffectNum++;
            _ready = false;

            yield return new WaitForSeconds(_durationBetweenFastParticles);

            _ready = true;
        }
        else
        {
            Instantiate(_slowEffect, new Vector2(Camera.main.rect.width / 2, Camera.main.rect.height / 2), Quaternion.Euler(0, 0, 0));
            _ready = false;
        }

        yield return null;
    }
}
