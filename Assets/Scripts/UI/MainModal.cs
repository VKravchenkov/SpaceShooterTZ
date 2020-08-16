using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainModal : BaseView
{
    public static MainModal Instance { get; private set; }

    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;

    private void Awake()
    {
        Instance = this;

        playButton.onClick.AddListener(OnClickPlayButton);
        settingsButton.onClick.AddListener(OnClickSettingsButton);
    }

    private void OnClickPlayButton()
    {
        EventManager.OnClickPlayButton();

        LevelModal.Instance.Show();

        Close();

        EventManager.ClickSound();
    }

    private void OnClickSettingsButton()
    {
        EventManager.OnClickSettingsButton();

        EventManager.ClickSound();
    }
}
