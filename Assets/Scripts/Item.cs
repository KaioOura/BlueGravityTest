using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _description;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private AnimationsPack _animationsPack;

    public AnimationsPack AnimationsPack => _animationsPack;

    public string ItemName => _itemName;

    public string Description => _description;

    public ItemType ItemType => _itemType;
    
}

public enum ItemType
{
    Equipment,
    Weapon,
    Accessory
}
