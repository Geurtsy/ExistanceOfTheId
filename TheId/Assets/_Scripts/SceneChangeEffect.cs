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
    [SerializeField] private GameObject _fastEffect;
    [SerializeField] private GameObject _slowEffect;
    [SerializeField] private float _durationBetweenFastParticles;

    private void Start()
    {
        StartCoroutine(ProduceEffect());
    }

    private IEnumerator ProduceEffect()
    {
        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Color beginColour = _mask.color;
        float step = 0.0f;

        while(step < 1.0f)
        {
            _mask.color = Color.Lerp(beginColour, _colourEnd, step);
        }


        Instantiate(_fastEffect, randomPositionOnScreen, transform.rotation);
        yield return null;
    }
}
