using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Symbole : MonoBehaviour
{
    
    [SerializeField] private Image _imageSymbole;

    
    [HideInInspector] public SymbolVFX _symbolVFX;
    
    public int Index;
    
    private int _index
    {
        get => Index;
        set =>_index = value;
        
    }
    

    private void Start()
    {
        _symbolVFX = GetComponent<SymbolVFX>();
    }

    public void InitializeSymboleData(int index, Sprite sprite)
    {
        _index = index;
        _imageSymbole.sprite = sprite;
    }
}
