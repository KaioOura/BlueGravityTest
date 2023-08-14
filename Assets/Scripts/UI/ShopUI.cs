using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Transform _container;

    [SerializeField] private CanvasGroup[] _canvasGroups;



    // Start is called before the first frame update
    public virtual void Start()
    {
        _canvasGroups[0].alpha = 1;
        _canvasGroups[0].interactable = true;
        _canvasGroups[0].blocksRaycasts = true;
        
        _canvasGroups[1].alpha = 0;
        _canvasGroups[1].interactable = false;
        _canvasGroups[1].blocksRaycasts = false;
    }

    public virtual void OnDestroy()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop(CanvasGroup canvasGroup)
    {
        for (int i = 0; i < _canvasGroups.Length; i++)
        {
            if (canvasGroup != _canvasGroups[i])
            {
                _canvasGroups[i].alpha = 0;
                _canvasGroups[i].interactable = false;
                _canvasGroups[i].blocksRaycasts = false;
            }
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    
}
