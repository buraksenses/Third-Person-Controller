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
        _sirhotEvents.OnDrawPistol();
    }

    public void ShootButtonOnClick()
    {
        _sirhotEvents.OnShoot();
    }

    #endregion
}
