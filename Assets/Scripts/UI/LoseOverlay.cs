using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseOverlay : BaseView
{
    public static LoseOverlay Instance { get; private set; }

    [SerializeField] private Button homeButton;
    [SerializeField] private Button replayButton;

    private void Awake()
    {
        Instance = this;

        homeButton.onClick.AddListener(OnClickHomeButton);
        replayButton.onClick.AddListener(OnClickReplayButton);
    }

    private void OnClickReplayButton()
    {
        Close();

        EventManager.ReplayLevel();

        EventManager.ClickSound();
    }

    private void OnClickHomeButton()
    {
        GameModal.Instance.Close();
        Close();

        MainModal.Instance.Show();

        //TODO
        EventManager.ClickSound();
    }
}
