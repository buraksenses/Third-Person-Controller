using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int StrafeMovement = Animator.StringToHash("StrafeMovement");
    private static readonly int LeftTurn = Animator.StringToHash("LeftTurn");
    private static readonly int IsTurning = Animator.StringToHash("isTurning");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int PistolIdle = Animator.StringToHash("Pistol Idle");

    private static readonly int iX = Animator.StringToHash("iX");
    private static readonly int iZ = Animator.StringToHash("iZ");

    private float _transitionTime = .25f;
    internal bool CanJumpAgain = true;

    internal float JumpCoolDownTime = 1.7f; // TODO: animation clip length will be used.

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.CrossFade(Idle,0,0);

        // ==== Event Assignments ====
        SirhotEvents.sirhotOnJump += PlayJumpAnimation;
        SirhotEvents.sirhotOnDrawPistol += PlayPistolIdleAnim;
    }

    private void PlayJumpAnimation()
    {
        if (!CanJumpAgain) return;
        StartCoroutine(PlayJumpAnimationRoutine());
    }
    
    private IEnumerator PlayJumpAnimationRoutine()
    {
        CanJumpAgain = false;
        animator.CrossFade(Jump,0,0);

        yield return new WaitForSeconds(JumpCoolDownTime);
        
        animator.CrossFade(Idle,_transitionTime,0);
        CanJumpAgain = true;
    }

    /// <summary>
    /// Sets the direction of the character
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    public void SetDirections(float x, float z)
    {
        animator.SetFloat(iX,x);
        animator.SetFloat(iZ,z);
    }

    public void PlayStrafeMovementAnimations()
    {
        animator.CrossFade(StrafeMovement,_transitionTime * .5f,0);
    }

    public void PlayIdleAnim()
    {
        animator.CrossFade(Idle,_transitionTime * 1.5f,0);
    }

    public void PlayPistolIdleAnim()
    {
        animator.CrossFade(PistolIdle,_transitionTime,1);
        animator.SetLayerWeight(1,1);
    }
}
