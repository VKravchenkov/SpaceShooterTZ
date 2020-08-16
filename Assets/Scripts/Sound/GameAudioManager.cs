using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : Singleton<GameAudioManager>
{
    [SerializeField] private SoundGroup background;
    [SerializeField] private SoundGroup clickButton;
    [SerializeField] private SoundGroup explosionAsteroid;
    [SerializeField] private SoundGroup explosionSpaceShip;
    [SerializeField] private SoundGroup Missile;

    protected override void Awake()
    {
        base.Awake();

        EventManager.OnRunBackgroundMusic += () => SoundPlayer.PlayMusic(background);
        EventManager.OnClickSound += () => SoundPlayer.PlaySfx(clickButton);
        EventManager.OnEplosionAsteroidSound += () => SoundPlayer.PlaySfx(explosionAsteroid);
        EventManager.OnExplosionSpaceShipSound += () => SoundPlayer.PlaySfx(explosionSpaceShip);
        EventManager.OnMissileSound += () => SoundPlayer.PlaySfx(Missile);
    }

    private void OnDisable()
    {
        EventManager.OnRunBackgroundMusic -= () => SoundPlayer.PlayMusic(background);
        EventManager.OnClickSound -= () => SoundPlayer.PlaySfx(clickButton);
        EventManager.OnEplosionAsteroidSound -= () => SoundPlayer.PlaySfx(explosionAsteroid);
        EventManager.OnExplosionSpaceShipSound -= () => SoundPlayer.PlaySfx(explosionSpaceShip);
        EventManager.OnMissileSound -= () => SoundPlayer.PlaySfx(Missile);
    }
}
