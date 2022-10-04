using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private SirhotEvents _sirhotEvents;

    private void Awake()
    {
        _sirhotEvents = FindObjectOfType<SirhotEvents>();
    }

    #region Button Methods

    public void JumpButtonOnClick()
    {
        _sirhotEvents.OnJump();
    }

    public void DrawPistolButtonOnClick()
    {
        if (GameManager.Instance.PistolState == PistolState.Down)
        {
            _sirhotEvents.OnDrawPistol();
            GameManager.Instance.PistolState = PistolState.Drawn;
        }
        else
        {
            _sirhotEvents.OnPistolDown();
            GameManager.Instance.PistolState = PistolState.Down;
        }
            
    }

    public void ShootButtonOnClick()
    {
        _sirhotEvents.OnShoot();
    }

    #endregion
}
