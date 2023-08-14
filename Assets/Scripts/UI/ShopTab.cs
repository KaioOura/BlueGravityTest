using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTab : MonoBehaviour
{
    [SerializeField] private Transform _itemSlotContainer;

    private List<ItemSlot> _itemSlots = new List<ItemSlot>();

    private void Awake()
    {
        foreach (Transform itemSlotTransform in _itemSlotContainer)
        {
            if (itemSlotTransform.TryGetComponent(out ItemSlot itemSlot))
                _itemSlots.Add(itemSlot);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PopulateShop(List<Item> items, Action<Item> tryBuyItem)
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            _itemSlots[i].gameObject.SetActive(false);
        }
        
        if (items.Count <= 0)
            return;
        
        if (items.Count > _itemSlots.Count)
            Debug.Log("There ar more items in Shop's stock than item slots. Populating the maximum number of itemSlot");

        for (int i = 0; i < _itemSlots.Count; i++)
        {
            if (i >= items.Count)
                break;
            _itemSlots[i].gameObject.SetActive(true);
            _itemSlots[i].UpdateItemSlot(items[i], tryBuyItem);
        }
    }
}
