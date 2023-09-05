using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pouet : MonoBehaviour
{
    private PlayerInput _playerInput;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Brique(InputAction.CallbackContext context)
    {
        Debug.Log("A");
        Debug.Log(context.started);
    }
}
