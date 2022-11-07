using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnerAdvanced : MonoBehaviour
{
    private ObjectPoolerAdvanced _objectPool;
    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPoolerAdvanced>();
    }

    // Update is called once per frame
    private void OnDisable()
    {
        if (_objectPool != null)
        {
            _objectPool.ReturnGameObject(this.gameObject);
        }
    }
}
