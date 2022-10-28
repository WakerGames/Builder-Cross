using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAdvanced : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 5f;
    private float _timeSinceSpawn;
    private ObjectPoolerAdvanced _objectPool;
    [SerializeField] private GameObject prefab;

    void SpawnPrefab()
    {
        GameObject newObject = _objectPool.GetObject(prefab);
        newObject.transform.position = new Vector3(GetComponent<BoxCollider>().size.x / 2, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z);
        newObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        _timeSinceSpawn = 0f;   
    }

    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPoolerAdvanced>();
    }
    
    void Update()
    {
        _timeSinceSpawn += Time.deltaTime;
        
        if (_timeSinceSpawn >= timeToSpawn)
        {
            SpawnPrefab();
        }

    }
}
