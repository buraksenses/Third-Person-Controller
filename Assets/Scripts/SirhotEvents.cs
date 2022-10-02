using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirhotEvents : MonoBehaviour
{
    public static event Action sirhotOnUpdate;
    public static event Action sirhotOnJump, sirhotOnDrawPistol,sirhotOnStrafeMovement,sirhotOnShoot;

    private void Update()
    {
        sirhotOnUpdate?.Invoke();
    }

    public void OnJump()
    {
        sirhotOnJump?.Invoke();
    }

    public void OnDrawPistol()
    {
        sirhotOnDrawPistol?.Invoke();
    }

    public void OnStrafeMovement()
    {
        sirhotOnStrafeMovement?.Invoke();
    }

    public void OnShoot()
    {
        sirhotOnShoot?.Invoke();
    }
}
