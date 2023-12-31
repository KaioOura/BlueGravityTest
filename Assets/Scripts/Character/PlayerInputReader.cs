using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput; 
    
    public event Action OnInputInventory; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputValue inputValue)
    {
        OnMoveInput?.Invoke(inputValue.Get<Vector2>());
    }

    private void OnInventory(InputValue value)
    {
        OnInputInventory?.Invoke();
    }
}
