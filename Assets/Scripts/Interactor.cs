using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    private IInteraction objectToInteract;
    
    // Update is called once per frame
    void Update()
    {
        if (objectToInteract == null)
            return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteraction obj))
            objectToInteract = obj;
    }
    
    
}
