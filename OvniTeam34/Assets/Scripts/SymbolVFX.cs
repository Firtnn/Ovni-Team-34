using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SymbolVFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve[] _animationCurves = new AnimationCurve[3];
    [SerializeField] private float _lerpTime;
    [SerializeField] float _startValue = 0; 
    [SerializeField] float _endValue = 1;
    [SerializeField] private Image _symboleImage;
    private Material _symboleMat;
    private int _lerpAmount = Shader.PropertyToID("_Amount");

    private void Awake()
    {
        _symboleMat = _symboleImage.material;
        _symboleMat.SetFloat(_lerpAmount, 0);
    }

    public void FadeInSymbol()
    {
        StartCoroutine(LerpThis());
    }

    private IEnumerator LerpThis()
    {
        float timeElapsed = 0;
        
        int rand = Random.Range(0, _animationCurves.Length);
        while (timeElapsed < _lerpTime)
        {
            timeElapsed += Time.deltaTime;
            _symboleMat.SetFloat(_lerpAmount, Mathf.Lerp(0, 1, _animationCurves[rand].Evaluate(timeElapsed)/_lerpTime));
            yield return null;
        }

        _symboleMat.SetFloat(_lerpAmount, 1);
    }
}
