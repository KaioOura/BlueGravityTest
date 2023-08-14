using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputByProximity : MonoBehaviour
{
    [SerializeField] private string _tagToCheck;

    [SerializeField] private UnityEvent _eventToInvoke;
    [SerializeField] private UnityEvent _eventToInvokeOnExit;
    
    private bool _inProximity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inProximity)
            return;
        
        //if (inpu)
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tagToCheck))
        {
            _inProximity = true;
            
            _eventToInvoke?.Invoke();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_tagToCheck))
        {
            _inProximity = false;
            
            _eventToInvokeOnExit?.Invoke();
        }
    }
}
