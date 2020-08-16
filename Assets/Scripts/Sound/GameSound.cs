using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misc/Sound", fileName = "New Sound")]
public class GameSound : ScriptableObject
{
    [SerializeField] private SoundGroup group;
    [SerializeField] private AudioClip clip;

    [Range(0, 1)]
    [SerializeField] private float volume = 1;

    public SoundGroup Group => group;
    public float Volume => volume;
    public AudioClip Clip => clip;
}

public enum SoundGroup
{
    Background = 0,
    ClickButton = 1,
    ExplosionAsteroid = 2,
    ExplosionSpaceShip = 3,
    Missile = 4
}
