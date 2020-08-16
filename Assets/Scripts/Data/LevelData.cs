using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "LevelData", order = 50)]
public class LevelData : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int countAsteroid;

    public int Level => level;
    public int CountAsteroid => countAsteroid;
}
