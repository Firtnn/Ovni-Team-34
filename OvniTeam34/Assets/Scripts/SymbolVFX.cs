using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SymbolVFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve[] _animationCurves;
    [SerializeField] private float _lerpTime;
    [SerializeField] float _startValue = 0; 
    [SerializeField] float _endValue = 10;
    

    public void FadeInSymbol()
    {
        StartCoroutine(LerpThis());
    }
    
    

    private IEnumerator LerpThis()
    {
        yield return null;
    }
}
