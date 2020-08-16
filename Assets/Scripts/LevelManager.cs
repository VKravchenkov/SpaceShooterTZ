using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<LevelData> levelDatas;
    [SerializeField] private LevelData levelDataSelected;

    public static List<LevelData> LevelDatas => Instance.levelDatas;

    protected override void Awake()
    {
        base.Awake();

        EventManager.OnCurrentLevel += (level) => levelDataSelected = level;
        EventManager.OnCheckRunLevel += CheckRunLevel;
    }


    private void OnDisable()
    {
        EventManager.OnCurrentLevel -= (level) => levelDataSelected = level;
        EventManager.OnCheckRunLevel -= CheckRunLevel;
    }

    private void CheckRunLevel(int count)
    {
        if (count == levelDataSelected.CountAsteroid)
        {
            EventManager.RunSpawn(false);
            EventManager.SpawnHideAsteroid();
            SaveManager.SetLastPassedLevel(levelDataSelected.Level);

            WinOverlay.Instance.Show();
        }
    }

    public static void NextLevel()
    {
        if (Instance.levelDataSelected.Level < Instance.levelDatas.Count)
        {
            EventManager.SetLevel(Instance.levelDatas[Instance.levelDataSelected.Level]);
        }
    }
}
