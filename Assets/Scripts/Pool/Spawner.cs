using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition;

    private ObjectPooler objectPooler;

    private int step;

    private bool isRunSpawn = false;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;

        EventManager.OnRunSpawnAsteroid += (isRun) => isRunSpawn = isRun;
        EventManager.OnRunSpawnMissile += (positionLeft, positionRight) => SpawnFromPoolMissile(positionLeft, positionRight);
        EventManager.OnSpawnHideAsteroid += () => objectPooler.SpawnHide();
        EventManager.OnSpawnExplosion += SpawnFromPoolExplosion;
    }

    private void FixedUpdate()
    {
        if (!isRunSpawn)
            return;

        step++;

        if (step == 20)
        {
            step = 0;
            SpawnFromPoolAsteroid();
        }
    }

    private void OnDisable()
    {
        EventManager.OnRunSpawnAsteroid -= (isRun) => isRunSpawn = isRun;
        EventManager.OnRunSpawnMissile -= (positionLeft, positionRight) => SpawnFromPoolMissile(positionLeft, positionRight);
        EventManager.OnSpawnHideAsteroid -= () => objectPooler.SpawnHide();
        EventManager.OnSpawnExplosion -= SpawnFromPoolExplosion;
    }

    private void SpawnFromPoolAsteroid()
    {
        Vector3 spawnValues = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);

        objectPooler.SpawnFromPool("Asteroid", spawnValues, Quaternion.identity);
    }

    private void SpawnFromPoolMissile(Vector3 shotSpawnLeftPosition, Vector3 shotSpawnRightPosition)
    {
        objectPooler.SpawnFromPool("Missile", shotSpawnLeftPosition, Quaternion.identity);
        objectPooler.SpawnFromPool("Missile", shotSpawnRightPosition, Quaternion.identity);
    }

    private void SpawnFromPoolExplosion(Vector3 positionExplosion)
    {
        objectPooler.SpawnFromPool("Explosion", positionExplosion, Quaternion.identity);
    }
}
