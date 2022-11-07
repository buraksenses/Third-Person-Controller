using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairHandler : MonoBehaviour
{
    private Image _crosshair;
    private void Awake()
    {
        EventManager.sirhotOnJump += CloseCrosshairOnJump;
        EventManager.sirhotOnGrounded += OpenCrosshairOnGrounded;
        
        EventManager.sirhotOnDrawPistol += OpenCrosshair;
        EventManager.sirhotOnPistolDown += CloseCrosshair;
    }

    private void Start()
    {
        _crosshair = GetComponent<Image>();
        _crosshair.enabled = false;
    }

    private void CloseCrosshair()
    {
        if (GameHandler.Instance.PistolState == PistolState.Down)
            _crosshair.enabled = false;
    }

    private void OpenCrosshair()
    {
        if (GameHandler.Instance.PistolState == PistolState.Drawn)
            _crosshair.enabled = true;
    }

    private void CloseCrosshairOnJump()
    {
        if(GameHandler.Instance.PistolState == PistolState.Drawn)
            _crosshair.enabled = false;
    }

    private void OpenCrosshairOnGrounded()
    {
        if(GameHandler.Instance.PistolState == PistolState.Drawn)
            _crosshair.enabled = true;
    }
}
