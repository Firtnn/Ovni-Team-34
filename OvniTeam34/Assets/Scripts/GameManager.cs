using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private float _score;
    private int _numberOfSymbols = 24;
    [SerializeField] private int _numberOfSentences = 10;

    [SerializeField] private List<string> _symbols = new List<string>();

    private List<int> _symbolsInBubble = new List<int>();

    private float _voiceSpeed;

    private void Start()
    {
        for (int i = 0; i < _numberOfSymbols; i++)
        {
            _symbols.Add("a" + i.ToString());
        }

        for (int i = 0; i < _numberOfSentences; i++)
        { 

        }
    }
}
