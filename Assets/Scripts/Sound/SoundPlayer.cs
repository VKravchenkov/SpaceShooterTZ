using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundPlayer : Singleton<SoundPlayer>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Range(0, 1)]
    [SerializeField] private float musicVolume = 1;

    [Range(0, 1)]
    [SerializeField] private float sfxVolume = 1;

    [SerializeField] private List<GameSound> sounds;

    public static float MusicVolume
    {
        get => Instance.musicVolume;
        set => Instance.musicVolume = value;
    }

    public static bool MusicMute
    {
        get => !Instance.musicSource.enabled;
        set => Instance.musicSource.enabled = !value;
    }

    public static float SfxVolume
    {
        get => Instance.sfxVolume;
        set => Instance.sfxVolume = value;
    }

    public static bool SfxMute
    {
        get => !Instance.sfxSource.enabled;
        set => Instance.sfxSource.enabled = !value;
    }

#if UNITY_EDITOR

    [SerializeField]
    private bool autoFind = true;

    [SerializeField]
    private string resourceFolder = "Game Sounds";

    void OnValidate()
    {
        if (!autoFind)
            return;

        sounds = Resources.LoadAll<GameSound>(resourceFolder).ToList();
    }

#endif

    public static GameSound GetSoundByType(SoundGroup group)
    {
        return Instance.sounds.FirstOrDefault(s => s.Group == group);
    }

    public static void PlayMusic(SoundGroup group)
    {
        var gameSound = GetSoundByType(group);

        if (!SoundCheck(group, gameSound))
            return;

        var volume = MusicVolume * gameSound.Volume;

        Instance.musicSource.volume = volume;
        Instance.musicSource.clip = gameSound.Clip;
        Instance.musicSource.Play();
    }

    public static void PlaySfx(SoundGroup group)
    {
        var gameSound = GetSoundByType(group);

        if (!SoundCheck(group, gameSound))
            return;

        if (SfxVolume * gameSound.Volume <= 0)
            return;

        Instance.sfxSource.PlayOneShot(gameSound.Clip, gameSound.Volume);
    }

    private static bool SoundCheck(SoundGroup soundGroup, GameSound sound)
    {
        if (sound == null)
        {
            Debug.LogError($"There is no such {nameof(GameSound)} of type: [{soundGroup}]!");
            return false;
        }

        if (sound.Clip == null)
        {
            Debug.LogError($"There is no such {nameof(AudioClip)} in {nameof(GameSound)} with name: [{sound.name}]!");
            return false;
        }

        if (Math.Abs(sound.Volume) < 0.0001f)
        {
            Debug.LogError($"Too small volume in {nameof(GameSound)} with name: [{sound.name}]!");
        }

        return true;
    }

}
