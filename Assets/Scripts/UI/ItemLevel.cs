using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevel : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private Image iconPassed;
    [SerializeField] private Image iconClosed;
    public StateLevel StateLevel { get; private set; }
    public LevelData LevelData { get; private set; }

    private void Awake()
    {
        levelButton.onClick.AddListener(OnClickLevelButton);
    }

    public void SetTextName(string name)
    {
        textName.text = name;
    }

    public void SetState(StateLevel state)
    {
        StateLevel = state;

        switch (StateLevel)
        {
            case StateLevel.Opened:
                iconClosed.gameObject.SetActive(false);
                iconPassed.gameObject.SetActive(false);
                break;
            case StateLevel.Passed:
                iconClosed.gameObject.SetActive(false);
                iconPassed.gameObject.SetActive(true);
                break;
            case StateLevel.Closed:
                iconClosed.gameObject.SetActive(true);
                iconPassed.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void SetLevelData(LevelData levelData)
    {
        LevelData = levelData;
    }

    private void OnClickLevelButton()
    {
        if (StateLevel == StateLevel.Opened || StateLevel == StateLevel.Passed)
        {
            EventManager.RunSpawn(true);

            LevelModal.Instance.Close();
            GameModal.Instance.Show();

            EventManager.SetLevel(LevelData);
            EventManager.StartGame();
        }
        EventManager.ClickSound();
    }
}

public enum StateLevel
{
    Opened = 0,
    Passed = 1,
    Closed = 2
}

