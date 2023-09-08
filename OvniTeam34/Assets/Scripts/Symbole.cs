using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Symbole : MonoBehaviour
{
    
    public Sprite _spriteSymbole;


    
    public SymbolVFX symbolVFX;
    
    public int Index;


    

    private void Start()
    {
        symbolVFX = GetComponent<SymbolVFX>();
    }

    public void InitializeSymboleData(int index, Sprite sprite)
    {
        Index = index;
        _spriteSymbole = sprite;
        GetComponent<Image>().sprite = _spriteSymbole;
    }
}
