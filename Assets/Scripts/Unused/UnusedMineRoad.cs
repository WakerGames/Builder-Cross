using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineRoadLegacy : MonoBehaviour
{
    [SerializeField] private GameObject minePrefab;
    public List<Vector3> _spawnPoints = new List<Vector3>(); // this script is coded for there to be 7 points only
    public Vector3[] tempPoint = new Vector3[7];

    // Start is called before the first frame update
    void Start()
    {
        var boxPart = this.GameObject().GetComponent<BoxCollider>().size.x / 7;

        for (int i = 0; i < 7; i++)
        {
            tempPoint[i] = new Vector3(
                this.GameObject().GetComponent<BoxCollider>().center.x -
                this.GameObject().GetComponent<BoxCollider>().size.x / 2 + boxPart * (i + 1) - boxPart / 2,
                this.GameObject().GetComponent<BoxCollider>().size.y,
                this.GameObject().GetComponent<BoxCollider>().size.z + this.GameObject().GetComponent<BoxCollider>().size.z / 2);


            //tempPoint[i] = new Vector3(boxPart * (i + 1), this.GameObject().GetComponent<BoxCollider>().size.y,
            //this.GameObject().GetComponent<BoxCollider>().size.z);


            for (int j = 0; j < _spawnPoints.Count; j++)
            {
                Debug.Log(_spawnPoints[j].ToString());
            }
        }

        Debug.Log(this.GameObject().GetComponent<BoxCollider>().center.x);
        Debug.Log(this.GameObject().GetComponent<BoxCollider>().size.x / 2);
    }

    // Update is called once per frame
    void Update()
    {
    }
}