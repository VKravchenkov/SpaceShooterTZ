using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject gameObj = Instantiate(pool.Prefab[Random.Range(0, pool.Prefab.Length)]);

                gameObj.SetActive(false);
                objectPool.Enqueue(gameObj);
            }

            poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject gameObjectToSpawn = poolDictionary[tag].Dequeue();

        gameObjectToSpawn.SetActive(true);
        gameObjectToSpawn.transform.position = position;
        gameObjectToSpawn.transform.rotation = rotation;

        IPolledObject polledObject = gameObjectToSpawn.GetComponent<IPolledObject>();

        if (polledObject != null)
            polledObject.OnObjectSpawn();

        poolDictionary[tag].Enqueue(gameObjectToSpawn);

        return gameObjectToSpawn;
    }

    public void SpawnHide()
    {
        foreach (Pool pool in pools)
        {
            poolDictionary[pool.Tag]
            .ToList()
            .ForEach(item => item.SetActive(false));
        }
    }

}

[Serializable]
public class Pool
{
    public string Tag;
    public GameObject[] Prefab;
    public int Size;
}
