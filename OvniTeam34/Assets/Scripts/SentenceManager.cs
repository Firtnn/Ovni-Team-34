using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

public class SentenceManager : MonoBehaviour
{
    private int _numberOfSymbols = 24;
    [SerializeField] private List<int> _symbols = new List<int>();

    [SerializeField] private float _timeScale;

    [SerializeField] private float _presidentTalkTime = 0f;
    [SerializeField] private float _translationTime = 0f;

    private float _presidentMaxTime = 1f;
    private float _translationMaxTime = 1f;

    private bool _isPresidentTalking = false;
    private bool _isTranslating = false;

    [SerializeField] private UnityEvent _onStartPresidentDialogue;
    [SerializeField] private UnityEvent _onStartTranslation;
    [SerializeField] private UnityEvent _onStopPresidentDialogue;
    [SerializeField] private UnityEvent _onStopTranslation;

    [SerializeField] private List<int> _sentence = new List<int>();

    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    void Start()
    {
        for (int i = 0; i < _numberOfSymbols; i++)
        {
            _symbols.Add(i);
        }
        _sentence = GenerateSentence(5);
    }

    // Update is called once per frame
    void Update()
    {
        if(_presidentTalkTime <= _presidentMaxTime && _isPresidentTalking)
        {
            _presidentTalkTime += Time.deltaTime * _timeScale;
        }
        if (_translationTime <= _translationMaxTime && _isTranslating)
        {
            _translationTime += Time.deltaTime * _timeScale;
        }
    }

    public void StartPresidentDialogue()
    {
        _onStartPresidentDialogue.Invoke();
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

    public void TranslatorDialogue()
    {
        StartCoroutine(PrintingTranslationDelay());
    }

    public List<int> GenerateSentence(int sentenceSize)
    {
        List<int> sentence = new List<int>();
        for (int i = 0; i < sentenceSize; i++)
        {

            int index = Random.Range(_symbols.Count - 1, 0);
            int symbol = _symbols[index];
            sentence.Add(symbol);
        }
        return sentence;
    }

    IEnumerator PrintingTranslationDelay()
    {
        yield return new WaitForSeconds(2f);
    }
}
