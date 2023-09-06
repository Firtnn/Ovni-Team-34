using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SymbolVFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve[] _animationCurves;
    [SerializeField] private float _lerpTime;
    [SerializeField] float _startValue = 0; 
    [SerializeField] float _endValue = 10;
    [SerializeField] private Image _symboleImage;
    

    public void FadeInSymbol()
    {
        StartCoroutine(LerpThis());
    }
    
    

    private IEnumerator LerpThis()
    {
        float timeElapsed = 0;
        while (timeElapsed < _lerpTime)
        {
            
            yield return null;
        }
        
    }
}
