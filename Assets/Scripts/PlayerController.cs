using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private Transform _transform;

    private PlayerAnimator _playerAnimator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _transform = this.transform;
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _transform.position += new Vector3(x * Time.deltaTime * 5f, 0, z * Time.deltaTime * 5f);
        _playerAnimator.SetDirections(x,z);
    }
}
