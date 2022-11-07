using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private EventManager _sirhotEvents;

    private void Awake()
    {
        _sirhotEvents = FindObjectOfType<EventManager>();
    }

    #region Button Methods

    public void JumpButtonOnClick()
    {
        _sirhotEvents.OnJump();
    }

    public void DrawPistolButtonOnClick()
    {
        if (GameHandler.Instance.PistolState == PistolState.Down)
        {
            GameHandler.Instance.PistolState = PistolState.Drawn;
            _sirhotEvents.OnDrawPistol();
        }
        else
        {
            GameHandler.Instance.PistolState = PistolState.Down;
            _sirhotEvents.OnPistolDown();
        }
            
    }

    public void ShootButtonOnClick()
    {
        _sirhotEvents.OnShoot();
    }

    #endregion
}
