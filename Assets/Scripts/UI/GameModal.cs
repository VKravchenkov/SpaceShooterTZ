using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModal : BaseView
{
    public static GameModal Instance { get; private set; }

    [SerializeField] private Button pauseButton;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Button fireButton;
    [SerializeField] private TMP_Text textLayer;
    [SerializeField] private TMP_Text textScore;

    private int currentScore;

    private void Awake()
    {
        Instance = this;

        pauseButton.onClick.AddListener(OnClickPauseButton);
        fireButton.onClick.AddListener(OnClickFireButton);
    }

    private void OnEnable()
    {
        EventManager.OnCurrentScore += SetTextScore;
        EventManager.OnCurrentLevel += (levelData) =>
        {
            SetTextLevel(levelData.Level);
            ClearScore();
        };

        EventManager.OnReplayLevel += ClearScore;
    }

    private void OnDisable()
    {
        EventManager.OnCurrentScore -= SetTextScore;
        EventManager.OnCurrentLevel -= (levelData) =>
        {
            SetTextLevel(levelData.Level);
            ClearScore();
        };

        EventManager.OnReplayLevel -= ClearScore;
    }
#if UNITY_ANDROID
    private void FixedUpdate()
    {
        EventManager.JoystickClick(joystick.Horizontal, joystick.Vertical);
    }
#endif
    private void OnClickPauseButton()
    {
        //Pause
        EventManager.ClickSound();
    }

    private void OnClickFireButton()
    {
        EventManager.FireClick();
    }

    private void SetTextScore(int score)
    {
        currentScore += score;
        textScore.text = currentScore.ToString();

        EventManager.CheckRunLevel(currentScore);
    }

    private void SetTextLevel(int layer)
    {
        textLayer.text = layer.ToString();
    }

    private void ClearScore()
    {
        currentScore = 0;
        textScore.text = currentScore.ToString();
    }
}
