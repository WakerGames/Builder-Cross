using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string prefabTag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance { get; private set; }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    

    private void Awake()        //Singleton
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        //PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        //foreach (Pool pool in pools)
        //{
        //    Queue<GameObject> objectPool = new Queue<GameObject>();

        //    for (int i = 0; i < pool.size; i++)
        //    {
        //        GameObject obj = PrefabUtility.InstantiatePrefab(pool.prefab) as GameObject;
        //        if (obj != null) obj.SetActive(false);
        //        objectPool.Enqueue(obj);
        //    }
        //    PoolDictionary.Add(pool.prefabTag, objectPool);
        //}
    }

    public GameObject SpawnFromPool(string prefabTag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(prefabTag))
        {
            Debug.Log("Pool with tag " + prefabTag + " doesn't exist");
            return null;
        }
        
        
        GameObject objectToSpawn = PoolDictionary[prefabTag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        PoolDictionary[prefabTag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}