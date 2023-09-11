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
    [SerializeField] private float _clignottementDelay;
    [SerializeField] private int _numberOfSentences;

    private bool _isPlaying = false;
    private bool _isTraduction = false;
    private bool _isTextVisible = true;

    private GameObject _menuIntroUI;
    private GameObject _clock;
    private GameObject _presBox;
    private GameObject _tradBox;
    private GameObject _startText;

    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameOverBehavior _gameOverBehavior;

    [SerializeField] private DialogueBox _tradDialogueBox;
    private List<int> _symbolsInBubble = new List<int>();

    public float _launchingDelay;
    
    private float _voiceSpeed;

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LancementJeuDelay(_launchingDelay));
        _menuIntroUI.SetActive(false);
        _presBox.SetActive(true);
        _clock.SetActive(true);
        _isPlaying = true;
        FindObjectOfType<AudioManager>().Stop("MusicMenu");
        FindObjectOfType<AudioManager>().Play("Music_Jeu");
    }

    IEnumerator LancementJeuDelay(float launchingDelay)
    {
        yield return new WaitForSeconds(launchingDelay);
        sentenceManager.GlobalLoop(_numberOfSentences);
    }



    public void TexteClignottant()
    {
        _startText = GameObject.Find("StartText");
        _startText.SetActive(true);
        StartCoroutine(Clignottement(_clignottementDelay));

    }

    IEnumerator Clignottement(float clignottementDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(clignottementDelay);
            _startText.SetActive(!_isTextVisible);
            _isTextVisible = !_isTextVisible;
        }
    }

        private void Start()
    {
        _menuIntroUI = GameObject.Find("IntroMenu");
        _clock = GameObject.Find("Clock");
        _presBox = GameObject.Find("PresBox");
        _tradBox = GameObject.Find("TradBox");
        _presBox.SetActive(false);
        _clock.SetActive(false);
        TexteClignottant();
        FindObjectOfType<AudioManager>().Play("MusicMenu");
    }

    private void Update()
    {
        if (!_isPlaying && Input.anyKey)
        {
            StartGame(); 
        }

       
    

        if (_isPlaying && sentenceManager._isTranslating && !_tradDialogueBox._isTradFull )
        {
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _tradDialogueBox.SetCurrentTradSymbol(0);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _tradDialogueBox.SetCurrentTradSymbol(1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                _tradDialogueBox.SetCurrentTradSymbol(2);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                _tradDialogueBox.SetCurrentTradSymbol(3);
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                _tradDialogueBox.SetCurrentTradSymbol(4);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                _tradDialogueBox.SetCurrentTradSymbol(5);
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                _tradDialogueBox.SetCurrentTradSymbol(6);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                _tradDialogueBox.SetCurrentTradSymbol(7);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _tradDialogueBox.SetCurrentTradSymbol(8);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _tradDialogueBox.SetCurrentTradSymbol(9);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _tradDialogueBox.SetCurrentTradSymbol(10);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                _tradDialogueBox.SetCurrentTradSymbol(11);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                _tradDialogueBox.SetCurrentTradSymbol(12);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                _tradDialogueBox.SetCurrentTradSymbol(13);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                _tradDialogueBox.SetCurrentTradSymbol(14);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                _tradDialogueBox.SetCurrentTradSymbol(15);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                _tradDialogueBox.SetCurrentTradSymbol(16);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                _tradDialogueBox.SetCurrentTradSymbol(17);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                _tradDialogueBox.SetCurrentTradSymbol(18);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                _tradDialogueBox.SetCurrentTradSymbol(19);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                _tradDialogueBox.SetCurrentTradSymbol(20);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                _tradDialogueBox.SetCurrentTradSymbol(21);
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                _tradDialogueBox.SetCurrentTradSymbol(22);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                _tradDialogueBox.SetCurrentTradSymbol(23);
            }
            _tradDialogueBox.CheckIsFull();
        }
    }

    public void IsGameOver()
    {
        Debug.Log(sentenceManager._currentSentence == 12);
        
            _endMenu.SetActive(true);
            _isPlaying = false;
            if (sentenceManager.numberOfGoodTranslation > 5)
            {
                _gameOverBehavior.SetVictoryDefeat(false);
            }
            else
            {
                
                _gameOverBehavior.SetVictoryDefeat(true);
            }
        
    }
}
