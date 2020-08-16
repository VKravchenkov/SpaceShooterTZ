using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModal : BaseView
{
    public static LevelModal Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
