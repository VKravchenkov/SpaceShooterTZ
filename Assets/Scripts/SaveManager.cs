using System;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private PlayerData playerData;

    public static int LastPassedLevel => Instance.playerData.lastPassedLavel;

    protected override void Awake()
    {
        base.Awake();

        LoadPlayerData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SavePlayerData();
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }

    private void LoadPlayerData()
    {
        playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData")) ??
            new PlayerData()
            {
                lastPassedLavel = 0
            };
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
        PlayerPrefs.Save();
    }

    public static void SetLastPassedLevel(int level)
    {
        if (level >= Instance.playerData.lastPassedLavel)
            Instance.playerData.lastPassedLavel = level;
    }

}
[Serializable]
public class PlayerData
{
    public int lastPassedLavel;
}
