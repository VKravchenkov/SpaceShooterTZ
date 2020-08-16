using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event Action PlayButtonClick;
    public static event Action SettingsButtonClick;

    public static event Action<LevelData> OnCurrentLevel;
    public static event Action<int> OnCurrentScore;

    public static event Action OnHitPlayer;
    public static event Action GameOver;
    public static event Action OnStartGame;
    public static event Action OnReplayLevel;

    public static event Action OnUpdatePlayerData;
    public static event Action<int> OnCheckRunLevel;

    // Sound
    public static event Action OnRunBackgroundMusic;
    public static event Action OnClickSound;
    public static event Action OnEplosionAsteroidSound;
    public static event Action OnExplosionSpaceShipSound;
    public static event Action OnMissileSound;

    public static event Action<bool> OnRunSpawnAsteroid;
    public static event Action OnSpawnHideAsteroid;
    public static event Action<Vector3, Vector3> OnRunSpawnMissile;
    public static event Action<Vector3> OnSpawnExplosion;

    public static event Action<float, float> OnJoystickClick;
    public static event Action OnFireClick;

    public static void OnClickPlayButton() => PlayButtonClick?.Invoke();
    public static void OnClickSettingsButton() => SettingsButtonClick?.Invoke();
    public static void ChangeScore(int score) => OnCurrentScore?.Invoke(score);
    public static void SetLevel(LevelData layer) => OnCurrentLevel?.Invoke(layer);
    public static void HitPlayer() => OnHitPlayer?.Invoke();
    public static void StartGame() => OnStartGame?.Invoke();
    public static void ReplayLevel() => OnReplayLevel?.Invoke();
    public static void EndGame() => GameOver?.Invoke();
    public static void UpdatePlayerData() => OnUpdatePlayerData?.Invoke();
    public static void CheckRunLevel(int countAsteroid) => OnCheckRunLevel?.Invoke(countAsteroid);
    public static void RunBackgroundMusic() => OnRunBackgroundMusic?.Invoke();
    public static void ClickSound() => OnClickSound?.Invoke();
    public static void EplosionAsteroidSound() => OnEplosionAsteroidSound?.Invoke();
    public static void ExplosionSpaceShipSound() => OnExplosionSpaceShipSound?.Invoke();
    public static void MissileSound() => OnMissileSound?.Invoke();
    public static void RunSpawn(bool isRun) => OnRunSpawnAsteroid?.Invoke(isRun);
    public static void RunSpawnMissile(Vector3 positionLeft, Vector3 positionRight) => OnRunSpawnMissile?.Invoke(positionLeft, positionRight);
    public static void SpawnHideAsteroid() => OnSpawnHideAsteroid?.Invoke();
    public static void RunSpawnExplosion(Vector3 position) => OnSpawnExplosion?.Invoke(position);
    public static void JoystickClick(float horizontal, float vertical) => OnJoystickClick?.Invoke(horizontal, vertical);
    public static void FireClick() => OnFireClick?.Invoke();
}
