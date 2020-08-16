using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOverlay : BaseView
{
    public static WinOverlay Instance { get; private set; }

    [SerializeField] private Button replayButton;
    [SerializeField] private Button NextButton;

    private void Awake()
    {
        Instance = this;

        replayButton.onClick.AddListener(OnClickReplayButton);
        NextButton.onClick.AddListener(OnClickNextButton);
    }

    private void OnClickNextButton()
    {
        LevelManager.NextLevel();

        EventManager.RunSpawn(true);
        Close();

        EventManager.ClickSound();
    }

    private void OnClickReplayButton()
    {
        Close();
        EventManager.ReplayLevel();

        EventManager.ClickSound();
    }
}
