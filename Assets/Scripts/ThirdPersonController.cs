using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
   public FixedJoystick leftJoystick;
   public FixedTouchField touchField;
   private PlayerAnimator _playerAnimator;
   private Rigidbody _rigidbody;
   private SirhotEvents _sirhotEvents;

   private Transform _mainCameraTR;
   private Transform _transform;
   private Transform _lookAtObject;

   private Camera _mainCamera;

   private float _x;
   private float _z;
   private float _animTransitionSpeed = 10f;
   private float _cameraAngleSpeed = .1f;
   private float _cameraPosY = 3f;
   private float _cameraAngleY;
   private float _moveSpeed = .01f;

   private float _scopedFOV = 50f;
   private float _unscopedFOV = 60f;
   private float _rotateSensitivity = 30f;
  
   private readonly Vector3 _angleVector = new (0, 3, 4);
   private Vector3 _lookAtObjectPosition;

   
   private bool _isMoving;

   private void Awake()
   {
      _playerAnimator = GetComponent<PlayerAnimator>();
      _mainCameraTR = Camera.main.transform;
      _transform = this.transform;
      _lookAtObject = _mainCameraTR.GetChild(0);
      _lookAtObjectPosition = _lookAtObject.position;
      _mainCamera = Camera.main;
   }

   private void Start()
   {
      // ==== Event Assignments ====
      SirhotEvents.sirhotOnUpdate += CharacterAnimationOperations;
      SirhotEvents.sirhotOnUpdate += CharacterTransformOperations;
      SirhotEvents.sirhotOnUpdate += CameraOperations;
      SirhotEvents.sirhotOnDrawPistol += OnDrawPistol;
      SirhotEvents.sirhotOnPistolDown += OnDrawPistol;
   }

   private void CharacterAnimationOperations()
   {
      //ANIMATOR CONTROLS
      _playerAnimator.SetDirections(_x,_z);

      _x = Mathf.Lerp(_x, leftJoystick.Horizontal, 2 * Time.deltaTime);
      _z = Mathf.Lerp(_z, leftJoystick.Vertical, 2 * Time.deltaTime);
     

      if (leftJoystick.triggered)
      {
         if (_isMoving || !_playerAnimator.CanJumpAgain) return;
         _playerAnimator.PlayStrafeMovementAnimations();
         _isMoving = true;
      }

      else
      {
         if (!_isMoving) return;
         _playerAnimator.PlayIdleAnim();
         _isMoving = false;
      }
   }

   private void CameraOperations()
   {
      //CACHING
      var cameraTr = _mainCameraTR;
      var transform1 = _transform;
      var position = transform1.position;
      var lookAtObjectTransform = _lookAtObject;
      
      //CAMERA POSITION AND ROTATION CONTROLS
      _cameraAngleY += touchField.TouchDist.x * _cameraAngleSpeed;
      cameraTr.position = position - Quaternion.AngleAxis(_cameraAngleY, Vector3.up) * _angleVector + new Vector3(0,_cameraPosY,0);
      cameraTr.rotation = Quaternion.LookRotation(position + Vector3.up * 2f - cameraTr.position, Vector3.up);
      lookAtObjectTransform.position = new Vector3(lookAtObjectTransform.position.x ,_lookAtObjectPosition.y,lookAtObjectTransform.position.z);

      float cameraPosSpeed = .003f;
      _cameraPosY = Mathf.Clamp(_cameraPosY - touchField.TouchDist.y * cameraPosSpeed, 4.5f, 6.5f);
   }

   private void CharacterTransformOperations()
   {
      //CACHING
      var transform1 = _transform;
      var position = transform1.position;
      
      //CHARACTER'S POSITION CONTROLS
      var input = new Vector3(leftJoystick.Horizontal, 0, leftJoystick.Vertical);
      var vel = Quaternion.AngleAxis(_cameraAngleY, Vector3.up) * input * _moveSpeed;
      position += new Vector3(vel.x, 0, vel.z);
      transform1.position = position;
      
      //CHARACTER'S ROTATION CONTROLS
      var targetRotation = Quaternion.LookRotation(_lookAtObject.position - position);
      transform1.rotation = Quaternion.Slerp(transform1.rotation, targetRotation, Time.deltaTime * _rotateSensitivity);
      // TODO: Rotation daha smooth yapılabilir.
   }

   private void OnDrawPistol()
   {
      float cameraFOV = _mainCamera.fieldOfView;
      _mainCamera.fieldOfView = Mathf.Approximately(_scopedFOV,cameraFOV) ? _unscopedFOV : _scopedFOV;
   }
}
