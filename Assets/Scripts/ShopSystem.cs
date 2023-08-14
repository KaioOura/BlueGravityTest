using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject ShopUI;
    
    [SerializeField] 
    private ShopInventory _shopInventory;

    [SerializeField]
    private Inventory buyerInventory;

    private List<Item> _currentStock;
    private List<Item> _currentSellerStock;

    public event Action<List<Item>, Action<Item>> OnOpenShop;
    public event Action<List<Item>, Action<Item>> OnOpenSell;
    public event Action OnCloseShop; 

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        OnOpenShop += _shopInventory.TryOpenInventory;
        OnOpenSell += _shopInventory.OpenSellInventory;

        OnCloseShop += _shopInventory.CloseInventory;
    }

    private void OnDestroy()
    {
        OnOpenShop -= _shopInventory.TryOpenInventory;
        OnOpenSell -= _shopInventory.OpenSellInventory;
        
        OnCloseShop -= _shopInventory.CloseInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateStock()
    {
        _currentStock = _shopInventory.GetListOfItems();
        _currentSellerStock = buyerInventory.GetListOfItems();
    }

    void OpenShop()
    {
        ShopUI.SetActive(true);
        
        UpdateStock();
        
        OnOpenShop?.Invoke(_currentStock, TryBuyItem);
        OnOpenSell?.Invoke(_currentSellerStock, TrySellItem);
    }

    public void CloseShop()
    {
        OnCloseShop?.Invoke();
    }
    
    public void TryBuyItem(Item item)
    {
        if (item.Price > buyerInventory.Coins)
            return;
        
        if (buyerInventory.GetListOfItems().Contains(item))
            return;
        
        buyerInventory.AddItem(item);
        buyerInventory.RemoveCoins(item.Price);
        
        _shopInventory.RemoveItem(item);
        
        UpdateStock();
        
        OnOpenShop?.Invoke(_currentStock, TryBuyItem);
        OnOpenSell?.Invoke(_currentSellerStock, TrySellItem);
    }

    public void TrySellItem(Item item)
    {

        if (!buyerInventory.GetListOfItems().Contains(item))
            return;
        
        buyerInventory.RemoveItem(item);
        buyerInventory.AddCoins(item.Price);
        
        _shopInventory.AddItem(item);
        
        UpdateStock();
        
        OnOpenShop?.Invoke(_currentStock, TrySellItem);
        OnOpenSell?.Invoke(_currentSellerStock, TrySellItem);
    }
    
    public void Interact()
    {
        OpenShop();
    }
}
