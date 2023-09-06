using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Image _borderImage;
    private float _width;
    private float _height;
    private int _fadeIn = Shader.PropertyToID("_Distance");

    [SerializeField] private float _transitionDuration;
    
    private void Start()
    {
       _height = _borderImage.rectTransform.rect.height;
       _width = _borderImage.rectTransform.rect.width;
       _borderImage.material.SetFloat(_fadeIn, -0.4f);
    }

    [SerializeField] private float _boxHeight;
    [SerializeField] private float[] _boxWidth;
    
    public void InitializeBox(int numberOfSymbol)
    {
        _height = _boxHeight;
        _width = _boxWidth[numberOfSymbol];
    }


    public void FadeIn()
    {
        Debug.Log("Oui");
        _borderImage.material.DOFloat(1, _fadeIn, 0.5f);
    }
}
