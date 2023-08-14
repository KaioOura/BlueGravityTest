using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private AnimatorReference _animatorReference;
    [SerializeField] private ItemEquiper _itemEquiper;
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private CharacterLocomotion _characterLocomotion;
    [SerializeField] private Inventory _playerInventory;

    public event Action<List<Item>, Action<Item>> OnOpenInventory;  

    // Start is called before the first frame update
    void Start()
    {
        InitEquiper();
        InitInput();
        InitInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        _itemEquiper.OnItemEquipUpdateAnimations -= _animatorReference.OnUpdateAnimations;
        _playerInputReader.OnMoveInput -= _characterLocomotion.MoveInput;
        _playerInputReader.OnInputInventory -= OpenInventory;
    }

    void InitEquiper()
    {
        _itemEquiper.OnItemEquipUpdateAnimations += _animatorReference.OnUpdateAnimations;
    }

    void InitInput()
    {
        _playerInputReader.OnMoveInput += _characterLocomotion.MoveInput;
    }

    void InitInventory()
    {
        _playerInputReader.OnInputInventory += OpenInventory;
        OnOpenInventory += _playerInventory.TryOpenInventory;
    }

    void OpenInventory()
    {
        OnOpenInventory?.Invoke(_playerInventory.GetListOfItems(), _itemEquiper.EquipItem);
    }
}
