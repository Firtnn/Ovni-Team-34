using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Image _borderDialogueImage;
    private float _width;
    private float _height;
    private int _fadeIn = Shader.PropertyToID("_Distance");

    [SerializeField] private float _transitionDuration;
    
    [SerializeField] private float _boxHeight;
    [SerializeField] private float[] _boxWidth;
    
    [SerializeField] private RectTransform _startPos;
    [SerializeField] private RectTransform _endPos;
    [SerializeField] private float[] _lStartPos;
    [SerializeField] private float[] _lEndPos;
    [SerializeField] private RectTransform[] _symbolePos;
    [SerializeField] private float _delay;
    [SerializeField] private Symbole[] _symboles;

 
    private Coroutine _currentCoroutine;
    private void Start()
    {
        _borderDialogueImage.material.SetFloat(_fadeIn, -0.4f);
        //SetDialogueUI(2);
        
        
    }
    
    private void InitializeBox(int numberOfSymbol)
    {
        _borderDialogueImage.rectTransform.sizeDelta = new Vector2(_boxWidth[numberOfSymbol - 1] ,_boxHeight);
    }

    public void FadeIn()
    {
        _borderDialogueImage.material.DOFloat(1, _fadeIn, 0.5f);
    }

    public void SetDialogueUI(int numberOfSymbol)
    {
        FadeIn();
        InitializeBox(numberOfSymbol);
        /*
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(SetSymbolePos(numberOfSymbol));
        }
        */
        SetSymbolePos(numberOfSymbol);
    }
    

    private void SetSymbolePos(int numberOfSymbol)
    {
        _startPos.localPosition = new Vector3(_lStartPos[numberOfSymbol], _startPos.position.y, 0);
        _endPos.localPosition = new Vector3(_lEndPos[numberOfSymbol], _startPos.position.y, 0);
        for (int i = 0; i < numberOfSymbol; i++)
        {
            if (i != 0)
            {
                _symbolePos[i].localPosition = new Vector3(Mathf.Lerp(_startPos.localPosition.x, _endPos.localPosition.x, i/(numberOfSymbol - 1)), _symbolePos[i].position.y, 0); 
            }
            else
            {
                _symbolePos[i].localPosition = new Vector3(Mathf.Lerp(_startPos.localPosition.x, _endPos.localPosition.x, 0), _symbolePos[i].position.y, 0); 
            }
            _symboles[i]._symbolVFX.FadeInSymbol();
        }
        
    }


  

    public void TraductionSymbole()
    {
        
    }
}
