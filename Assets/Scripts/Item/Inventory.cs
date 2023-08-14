using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected InventoryUI _inventoryUI;
    [SerializeField] private List<Item> _items;

    [SerializeField]
    private int _coins;

    private bool _isOpen;
    
    public int Coins => _coins;

    public InventoryUI InventoryUI => _inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TryOpenInventory(List<Item> items, Action<Item> buttonAction)
    {
        if (!_isOpen)
            _inventoryUI.OpenInventory(items, buttonAction);
        else
            CloseInventory();

        _isOpen = !_isOpen;
    }

    public void CloseInventory()
    {
        _inventoryUI.CloseInventory();
    }
    
    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (_items.Contains(item))
            _items.Remove(item);
    }

    public void AddCoins(int coinsToAdd)
    {
        _coins += coinsToAdd;

        _coins = Math.Clamp(_coins, 0, 9999);
    }
    
    public void RemoveCoins(int coinsToRemove)
    {
        _coins -= coinsToRemove;

        _coins = Math.Clamp(_coins, 0, 9999);
    }
    
    public List<Item> GetListOfItems()
    {
        return _items;
    }
}
