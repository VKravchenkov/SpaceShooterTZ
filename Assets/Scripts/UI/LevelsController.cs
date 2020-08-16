using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private List<ItemLevel> itemLevels;

    [SerializeField] private GameObject prefabItemlevel;

    private void Start()
    {
        EventManager.OnUpdatePlayerData += UpdatePlayerData;

        InitLevels();
        UpdatePlayerData();
    }

    private void OnDisable()
    {
        EventManager.OnUpdatePlayerData -= UpdatePlayerData;
    }

    private void InitLevels()
    {
        itemLevels = new List<ItemLevel>();

        for (int i = 0; i < LevelManager.LevelDatas.Count; i++)
        {
            GameObject gameObject = Instantiate(prefabItemlevel, transform);

            ItemLevel itemLevel = gameObject.GetComponent<ItemLevel>();

            itemLevel.SetTextName(LevelManager.LevelDatas[i].name);
            itemLevel.SetLevelData(LevelManager.LevelDatas[i]);
            itemLevel.SetState(StateLevel.Closed);

            itemLevels.Add(itemLevel);
        }
    }

    private void UpdatePlayerData()
    {
        int lastPassedLevel = SaveManager.LastPassedLevel;

        if (lastPassedLevel == 0)
        {
            itemLevels[0].SetState(StateLevel.Opened);
            return;
        }

        for (int i = 0; i < lastPassedLevel; i++)
        {
            itemLevels[i].SetState(StateLevel.Passed);
        }

        if (lastPassedLevel < itemLevels.Count)
            itemLevels[lastPassedLevel].SetState(StateLevel.Opened);
    }
}
