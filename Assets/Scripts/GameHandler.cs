using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    
    public PistolState PistolState;

    private void Awake()
    {
        Instance = this;
        PistolState = PistolState.Down;
    }
}

public enum PistolState
{
    Drawn,
    Down
}