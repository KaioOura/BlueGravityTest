using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _description;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private AnimationClip _idle;
    [SerializeField] private AnimationClip _walkUp;
    [SerializeField] private AnimationClip _walkDown;
    [SerializeField] private AnimationClip _walkRight;
    [SerializeField] private AnimationClip _walkLeft;

    public AnimationClip Idle => _idle;

    public AnimationClip WalkUp => _walkUp;

    public AnimationClip WalkDown => _walkDown;

    public AnimationClip WalkRight => _walkRight;

    public AnimationClip WalkLeft => _walkLeft;

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
