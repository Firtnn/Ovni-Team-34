using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Symbole : MonoBehaviour
{
    public int Index;
    private int _index
    {
        get => Index;
        set =>_index = value;
        
    }


    [SerializeField] private Image _imageSymbole;


    public void InitializeSymboleData(int index, Sprite sprite)
    {
        _index = index;
        _imageSymbole.sprite = sprite;
    }
}
