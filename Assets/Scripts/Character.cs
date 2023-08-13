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
    
    // Start is called before the first frame update
    void Start()
    {
        InitEquiper();
        InitInput();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        _animatorReference.SetFloat("Horizontal", input.x);
        _animatorReference.SetFloat("Vertical", input.y);
    }

    private void OnDestroy()
    {
        _itemEquiper.OnItemEquipUpdateAnimations -= _animatorReference.OnUpdateAnimations;
        _playerInputReader.OnMoveInput -= _characterLocomotion.MoveInput;
    }

    void InitEquiper()
    {
        _itemEquiper.OnItemEquipUpdateAnimations += _animatorReference.OnUpdateAnimations;
    }

    void InitInput()
    {
        _playerInputReader.OnMoveInput += _characterLocomotion.MoveInput;
    }
    
}
