using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int FastRun = Animator.StringToHash("FastRun");
    private static readonly int StrafeRight = Animator.StringToHash("StrafeRight");
    private static readonly int StrafeLeft = Animator.StringToHash("StrafeLeft");
    private static readonly int StrafeBack = Animator.StringToHash("StrafeBack");
    private static readonly int LeftTurn = Animator.StringToHash("LeftTurn");
    private static readonly int IsTurning = Animator.StringToHash("isTurning");

    private static readonly int iX = Animator.StringToHash("iX");
    private static readonly int iZ = Animator.StringToHash("iZ");

    private float _transitionTime = .25f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetDirections(float x, float z)
    {
        _animator.SetFloat(iX,x);
        _animator.SetFloat(iZ,z);
    }

    public void PlayTurnAnimations(float x)
    {
        _animator.SetBool(IsTurning, x != 0);
    }
}
