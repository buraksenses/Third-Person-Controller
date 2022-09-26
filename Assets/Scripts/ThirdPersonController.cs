using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
   public FixedJoystick leftJoystick;
   public FixedTouchField touchField;
   private PlayerAnimator _animator;

   private float _x;
   private float _z;
   private float _animTransitionSpeed = 10f;
   private void Awake()
   {
      _animator = GetComponent<PlayerAnimator>();
   }

   private void Update()
   {
      if (true)
      {
         _animator.SetDirections(_x,_z);
         _x = Mathf.Lerp(_x , Mathf.Round(leftJoystick.Horizontal),_animTransitionSpeed * Time.deltaTime);
         _z = Mathf.Lerp(_z , Mathf.Round(leftJoystick.Vertical),_animTransitionSpeed * Time.deltaTime);
      }
   }
}
