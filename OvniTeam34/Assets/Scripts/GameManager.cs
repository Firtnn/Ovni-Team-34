using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SentenceManager sentenceManager;
    private float _score;
    [SerializeField] private int _numberOfSentences = 2;


    private List<int> _symbolsInBubble = new List<int>();

    private float _voiceSpeed;

    private void Start()
    {
        sentenceManager.GlobalLoop(_numberOfSentences);
    }
}
