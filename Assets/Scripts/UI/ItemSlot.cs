using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image slotImage;
    
    [SerializeField]
    private TextMeshProUGUI _priceText;
    
    [SerializeField]
    private Image purchasedFeedback;


    private Button _slotButton;
    private Item _item;

    private void Awake()
    {
        _slotButton = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //slotImage = GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateItemSlot(Item item, Action<Item> buttonAction)
    {
        _item = item;
        slotImage.sprite = _item.Sprite;
        _priceText.text = item.Price.ToString();

        if (_slotButton == null)
            Debug.Log(null);
        
        _slotButton.onClick.AddListener(() => buttonAction?.Invoke(item));
    }
    
}
