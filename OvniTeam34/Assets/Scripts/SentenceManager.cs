using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceManager : MonoBehaviour
{
    private GameManager gameManager;

    private int _numberOfSymbolsInSentence;

    private float _timeScale = 1;
    private int maxTime = 1;
    [SerializeField] private float _time = 0f;
    


    private List<int> _symbolsInSentence = new List<int>();

    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    void Start()
    {
        for (int i = 0; i<_numberOfSymbolsInSentence; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime*_timeScale;
    }
}
