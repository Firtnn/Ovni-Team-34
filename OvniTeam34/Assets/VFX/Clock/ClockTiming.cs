using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ClockTiming : MonoBehaviour
{
    
    [SerializeField] private Image _clockImage;
    private int _clockTimeAmount = Shader.PropertyToID("_TimeAmount");

    private bool _isOver; 
    
    public void SetClock(float remainingTime)
    {
        SetMatFloat(_clockTimeAmount, remainingTime);
    }

    public void RestartClock()
    {
        if (_isOver)
        {
            _isOver = false;
            SetMatFloat(_clockTimeAmount, 0);
        }
    }

    public void StopClock()
    {
        _isOver = true;
        SetMatFloat(_clockTimeAmount, 1);
    }

    private void SetMatFloat(int property, float time)
    {
        _clockImage.material.SetFloat(property, time);
    }
}
