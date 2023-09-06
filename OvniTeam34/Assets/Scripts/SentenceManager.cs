using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SentenceManager : MonoBehaviour
{
    private int _numberOfSymbols = 24;
    private List<int> _symbols = new List<int>();
    //private List<Image> _symbols = new List<Image>();

    [SerializeField]private List<int> _sizeOfSentences = new List<int>();

    [SerializeField] private float _timeScale;

    [SerializeField] private float _presidentTalkTime = 0f;
    [SerializeField] private float _translationTime = 0f;
    [SerializeField] private float _afterTranslationDelay = 2f;

    private float _presidentMaxTime = 1f;
    private float _translationMaxTime = 1f;

    [SerializeField] private int _currentSentence = 0;

    private bool _isPresidentTalking = false;
    private bool _isTranslating = false;

    [SerializeField] private int _sentenceTestSize;

    //[SerializeField] private Image _testImage;

    [Header("Events")]
    [Space(20)]
    public UnityEvent _onStartPresidentDialogue;
    public  UnityEvent _onStartTranslation;
    public  UnityEvent _onStopPresidentDialogue;
    public  UnityEvent _onStopTranslation;

    public  List<int> _sentence = new List<int>();
    //[SerializeField] private List<Image> _sentence = new List<Image>();

    [SerializeField] private ClockTiming _clockTiming;

    void Start()
    {
        for (int i = 0; i < _numberOfSymbols; i++)
        {
            //_symbols.Add(_testImage);
            _symbols.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPresidentTalking)
        {
            _presidentTalkTime += Time.deltaTime * _timeScale;
            _clockTiming.SetClock(_presidentTalkTime);
        }
        else
        {
            _presidentTalkTime = 0f;
        }
        if (_isTranslating)
        {
            _translationTime += Time.deltaTime * _timeScale;
            _clockTiming.SetClock(_translationTime);
        }
        else
        {
            _translationTime = 0f;
        }
    }

    public void StartPresidentDialogue(int sentenceSize)
    {
        _onStartPresidentDialogue.Invoke();
        GenerateSentence(sentenceSize);
        _isPresidentTalking = true;
    }

    public void StopPresidentDialogue()
    {
        _onStopPresidentDialogue.Invoke();
        _isPresidentTalking = false;
    }
    public void StartTranslation()
    {
        _onStartTranslation.Invoke();
        _isTranslating = true;
    }

    public void StopTranslation()
    {
        _onStopTranslation.Invoke();
        _isTranslating = false;
    }

    public void GenerateSentence(int sentenceSize)
    {
        _sentence.Clear();
        for (int i = 0; i < sentenceSize; i++)
        {

            int index = Random.Range(_symbols.Count - 1, 0);
            //Image symbol = _symbols[index];
            int symbol = _symbols[index];
            _sentence.Add(symbol);
        }
    }

    public void GlobalLoop(int numberOfTime)
    {
        StartCoroutine(GlobaLoopCoroutine(numberOfTime));
    }
    IEnumerator GlobaLoopCoroutine(int number)
    {
        StartPresidentDialogue(_sizeOfSentences[_currentSentence]);
        yield return new WaitForSeconds(_presidentMaxTime/_timeScale);
        StopPresidentDialogue();
        StartTranslation();
        yield return new WaitForSeconds(_translationMaxTime/ _timeScale);
        StopTranslation();
        yield return new WaitForSeconds(_afterTranslationDelay);
        if (_currentSentence < number - 1)
        {
            Debug.Log(number);
            _currentSentence += 1;
            yield return GlobaLoopCoroutine(number);
        }
    }
}