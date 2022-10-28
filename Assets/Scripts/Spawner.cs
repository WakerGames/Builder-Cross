using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    [SerializeField] private string spawnTag;
    [SerializeField] private float timeToSpawn;
    private float _timeSinceSpawn;

    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timeSinceSpawn += Time.deltaTime;
        if (_timeSinceSpawn >= timeToSpawn)
        {
            _objectPooler.SpawnFromPool(spawnTag.Trim(), new Vector3(transform.position.x + GetComponent<BoxCollider>().size.x / 2, transform.position.y, transform.position.z), Quaternion.Euler(0,-90,0));
            _timeSinceSpawn = 0f;
        }
    }
}
