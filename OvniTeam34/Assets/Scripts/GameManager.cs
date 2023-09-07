using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;

public class GameManager : MonoBehaviour
{
    public SentenceManager sentenceManager;
    private float _score;
    [SerializeField] private int _numberOfSentences;

    private bool _isPlaying = false;

    private GameObject _menuIntroUI;
    private GameObject _clock;
    private GameObject _presBox;
    private GameObject _tradBox;

    private List<int> _symbolsInBubble = new List<int>();

    private float _voiceSpeed;

    public void StartGame()
    {
        _menuIntroUI.SetActive(false);
        _presBox.SetActive(true);
        _clock.SetActive(true);
        sentenceManager.GlobalLoop(_numberOfSentences);
        _isPlaying = true;
    }

    private void Start()
    {
        _menuIntroUI = GameObject.Find("IntroMenu");
        _clock = GameObject.Find("Clock");
        _presBox = GameObject.Find("PresBox");
        _tradBox = GameObject.Find("TradBox");
        _presBox.SetActive(false);
        _clock.SetActive(false);
    }

    private void Update()
    {
        if (!_isPlaying && Input.anyKey)
        {
            StartGame(); 
        }
    }
}
