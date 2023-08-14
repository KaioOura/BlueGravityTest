using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputByProximity : MonoBehaviour
{
    [SerializeField] private string _tagToCheck;

    [SerializeField] private InputAction _inputAction;
    
    [SerializeField] private UnityEvent _eventToInvoke;
    [SerializeField] private UnityEvent _eventToInvokeOnExit;
    
    private bool _inProximity;

    // Start is called before the first frame update
    void Start()
    {

        _inputAction.performed += TryInvokeEvent;
    }

    private void OnDestroy()
    {
        _inputAction.performed -= TryInvokeEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inProximity)
            return;
        
        //if (inpu)
    }

    void TryInvokeEvent(InputAction.CallbackContext callbackContext)
    {
        if (!_inProximity)
            return;
        
        _eventToInvoke?.Invoke();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tagToCheck))
        {
            _inputAction.Enable();
            _inProximity = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_tagToCheck))
        {
            _inputAction.Disable();
            _inProximity = false;
            _eventToInvokeOnExit?.Invoke();
        }
    }
}
