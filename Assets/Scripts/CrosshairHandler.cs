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
        SirhotEvents.sirhotOnJump += CloseCrosshair;
        SirhotEvents.sirhotOnGrounded += OpenCrosshair;
        
        SirhotEvents.sirhotOnDrawPistol += OpenCrosshair;
        SirhotEvents.sirhotOnPistolDown += CloseCrosshair;
    }

    private void Start()
    {
        _crosshair = GetComponent<Image>();
        _crosshair.enabled = false;
    }

    private void CloseCrosshair()
    {
        if (GameManager.Instance.PistolState == PistolState.Down)
            _crosshair.enabled = false;
    }

    private void OpenCrosshair()
    {
        if (GameManager.Instance.PistolState == PistolState.Drawn)
            _crosshair.enabled = true;
    }
}
