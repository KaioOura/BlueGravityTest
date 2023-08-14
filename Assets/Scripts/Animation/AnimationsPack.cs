using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationsPack
{
    [SerializeField] 
    private AnimationClip _idle;
    
    [SerializeField] 
    private AnimationClip _up;
    [SerializeField] 
    private AnimationClip _down;
    [SerializeField] 
    private AnimationClip _right;
    [SerializeField] 
    private AnimationClip _left;

    public AnimationClip Idle => _idle;

    public AnimationClip Up => _up;

    public AnimationClip Down => _down;

    public AnimationClip Right => _right;

    public AnimationClip Left => _left;
}
