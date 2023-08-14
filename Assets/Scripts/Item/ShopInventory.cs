using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : Inventory
{
    [SerializeField] private InventoryUI _sellInventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TryOpenInventory(List<Item> items, Action<Item> buttonAction)
    {
        _inventoryUI.OpenInventory(items, buttonAction);
    }

    public void OpenSellInventory(List<Item> items, Action<Item> buttonAction)
    {
        _sellInventoryUI.OpenInventory(items, buttonAction);
    }
    
    public void CloseSellInventory()
    {
        _sellInventoryUI.CloseInventory();
    }
}
