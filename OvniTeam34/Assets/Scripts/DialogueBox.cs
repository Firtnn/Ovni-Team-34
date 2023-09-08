using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
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
    [SerializeField] private RectTransform _horizontalGroup;
    [SerializeField] private float[] _horizontalSpacing;
    [SerializeField] private float[] _horizontalPos;
    [HideInInspector] public bool _isTradFull = false;
    private int _currentTradNumber;

    [SerializeField] private Text _traductionText;

    [SerializeField] private SentenceManager _sentenceManager;

    [SerializeField] private SymboleScriptableData _data;

    private int _indexTradSymbol = 0;
 
    private Coroutine _currentCoroutine;
    private void Start()
    {
        _borderDialogueImage.material.SetFloat(_fadeIn, -0.4f);
    }
    
    private void InitializeBox(int numberOfSymbol)
    {
        _borderDialogueImage.rectTransform.sizeDelta = new Vector2(_boxWidth[numberOfSymbol - 1] ,_boxHeight);
    }

    public void FadeIn()
    {
        _borderDialogueImage.material.DOFloat(1, _fadeIn, 0.5f);
    }
    
    public void FadeOut()
    {
        _borderDialogueImage.material.DOFloat(-0.4f, _fadeIn, 0.5f);
    }

    public void SetDialogueUI(int numberOfSymbol)
    {
        FadeIn();
        InitializeBox(numberOfSymbol);
        SetPresHorizontalGroup(numberOfSymbol);
    }

    public void SetTradUI(int numberOfSymbol)
    {
        _indexTradSymbol = 0;
        FadeIn();
        InitializeBox(numberOfSymbol);
        SetTradHorizontalGroup(numberOfSymbol);
    }
    

    public void FadeOutSymbols()
    {
        for (int i = 0; i < _symboles.Length; i++)
        {
            _symboles[i].symbolVFX.FadeOut();
        }
    }



    private void SetPresHorizontalGroup(int numberOfSymbol)
    {
        _horizontalGroup.sizeDelta = new Vector2(_boxWidth[numberOfSymbol - 2] ,_boxHeight);
        _horizontalGroup.localPosition = new Vector2(_horizontalPos[numberOfSymbol - 2], -45);
        _horizontalGroup.GetComponent<HorizontalLayoutGroup>().spacing = _horizontalSpacing[numberOfSymbol - 2];
    
        
        for (int i = 0; i < _symboles.Length; i++)
        {
            if (i < numberOfSymbol)
            {
                _symboles[i].symbolVFX.FadeInSymbol();
                _symboles[i].InitializeSymboleData(_sentenceManager._presSentence[i], _data._logo[_sentenceManager._presSentence[i]]);
            }
            else
            {
                _symboles[i].symbolVFX.FadeOut();
            }

        }
        
    }
    
    private void SetTradHorizontalGroup(int numberOfSymbol)
    {
        _horizontalGroup.sizeDelta = new Vector2(_boxWidth[numberOfSymbol - 2] ,_boxHeight);
        _traductionText.rectTransform.sizeDelta = new Vector2(_boxWidth[numberOfSymbol - 2] - 5f, _boxHeight);
        _horizontalGroup.localPosition = new Vector2(_horizontalPos[numberOfSymbol - 2], -20);
        _horizontalGroup.GetComponent<HorizontalLayoutGroup>().spacing = _horizontalSpacing[numberOfSymbol - 2];
        _isTradFull = false;
        _sentenceManager.IsTranslationCorrect = true;
        _currentTradNumber = numberOfSymbol;

    }

    public void SetCurrentTradSymbol(int keyNumber)
    {
        Debug.Log(keyNumber);
        _symboles[_indexTradSymbol].InitializeSymboleData(keyNumber, _data._logo[keyNumber]);
        _symboles[_indexTradSymbol].symbolVFX.FadeInSymbol();
        if (keyNumber != _sentenceManager._presSentence[_indexTradSymbol])
        {
            _sentenceManager.IsTranslationCorrect = false;
        }
        _indexTradSymbol++;
        
    }

    public void SetHumanTraduction(bool isCorrect)
    {
        _traductionText.enabled = true;
        if (isCorrect)
        {
            _traductionText.text = _sentenceManager._correctSentence[_sentenceManager._currentSentence];
        }
        else
        {
            _traductionText.text = _sentenceManager._wrongSentence[_sentenceManager._currentSentence];
        }
    }

    public void DisableHumanTraduction()
    {
        _traductionText.text = (" ");;
    }

   

    public void CheckIsFull()
    {
        if (_indexTradSymbol >= _currentTradNumber)
        {
            _isTradFull = true;
        }
        
    }

    
}
