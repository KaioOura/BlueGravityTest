using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorReference : MonoBehaviour
{
    private List<Animator> _animators = new List<Animator>();

    [SerializeField] 
    private AnimationState _hairAnimationStates;
    [SerializeField] 
    private AnimationState _hatAnimationStates;
    [SerializeField] 
    private AnimationState _upperAnimationStates;
    [SerializeField] 
    private AnimationState _bottomAnimationStates;
    [SerializeField] 
    private AnimationState _fullBodyAnimationStates;
    
    [SerializeField] 
    private AnimatorOverrideController _animatorOverrideController;
    
    [SerializeField]
    private Animator _bodyAnimator;
    [SerializeField]
    private Animator _hairAnimator;
    [SerializeField]
    private Animator _hatAnimator;
    [SerializeField]
    private Animator _bottomAnimator;
    [SerializeField]
    private Animator _fullBodyPieceAnimator;
    
    private bool test;

    private void Awake()
    {
        //Having 1 variable for each animator will make it easier to get one specific if needed in the future
        _animators.Add(_bodyAnimator);
        _animators.Add(_hairAnimator);
        _animators.Add(_hatAnimator);
        _animators.Add(_bottomAnimator);
        _animators.Add(_fullBodyPieceAnimator);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitAnimatorLayers();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitAnimatorLayers()
    {
        EnableAnimatorLayers();
        UpdateRunTimeAnimatorController();
    }

    public void OnUpdateAnimations(int i, AnimationsPack animationsPack)
    {
        switch (i)
        {
            case 0: //Hair
            {
                break;
            }
            case 1: //Hat
            {
                _animatorOverrideController[_hatAnimationStates.Idle] = animationsPack.Idle;
                _animatorOverrideController[_hatAnimationStates.Up] = animationsPack.Up;
                _animatorOverrideController[_hatAnimationStates.Down] = animationsPack.Down;
                _animatorOverrideController[_hatAnimationStates.Right] = animationsPack.Right;
                _animatorOverrideController[_hatAnimationStates.Left] = animationsPack.Left;
                break;
            }
        }
    }

    void UpdateRunTimeAnimatorController()
    {
        for (int i = 0; i < _animators.Count; i++)
        {
            _animators[i].runtimeAnimatorController = _animatorOverrideController;
        } 
    }
    
    void EnableAnimatorLayers()
    {
        for (int i = 0; i < _animators.Count; i++)
        {
            _animators[i].SetLayerWeight(i, 1);
        }  
    }
    
    public void SetTrigger(string param)
    {
        foreach (var an in _animators)
        {
            an.SetTrigger(param);
        }
    }
    
    public void SetBool(string param, bool value)
    {
        foreach (var an in _animators)
        {
            an.SetBool(param, value);
        }
    }
    
    public void SetFloat(string param, float value)
    {
        foreach (var an in _animators)
        {
            an.SetFloat(param, value);
        }
    }
}

[System.Serializable]
public class AnimationState
{
    public AnimationClip Idle;
    public AnimationClip Up;
    public AnimationClip Down;
    public AnimationClip Right;
    public AnimationClip Left;
}
