using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairHandler : MonoBehaviour
{
    private void Awake()
    {
        SirhotEvents.sirhotOnJump += CloseCrosshair;
        SirhotEvents.sirhotOnGrounded += OpenCrosshair;
        
        SirhotEvents.sirhotOnDrawPistol += OpenCrosshair;
        SirhotEvents.sirhotOnPistolDown += CloseCrosshair;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void CloseCrosshair()
    {
        gameObject.SetActive(false);
    }

    private void OpenCrosshair()
    {
        gameObject.SetActive(true);
    }
}
