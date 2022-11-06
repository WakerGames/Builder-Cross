using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneratorAdvanced : MonoBehaviour
{
  /*
   * public static RoadGenerator Instance { get; set; }

    [SerializeField, CanBeNull] private Transform lastRoadTransform;
    [SerializeField] private GameObject collectibleRoad;
    [SerializeField] private GameObject emptyRoad;
    [SerializeField] private GameObject carRoad;
    [SerializeField] private GameObject turretRoad;
    [SerializeField] private GameObject droneRoad;
    private Vector3 _newRoadPosition;

    [Header("Level Generation")] 
    [SerializeField, Min(1)] private int collectibleAmount;
    [SerializeField, Min(1)] private int collectibleInterval;



    private enum RoadType
    {
        Collectible,
        Empty,
        Car,
        Turret,
        Drone
    }

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

    void ChangeTransform(GameObject newRoad)
    {
        if (newRoad != null)
        {
            newRoad.transform.position = _newRoadPosition;
            newRoad.transform.parent = this.transform;

            lastRoadTransform = newRoad.transform;
        }
    }

    void AddRoadPrefab(RoadType roadType)
    {
        if (lastRoadTransform == null)
        {
            lastRoadTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        
        GameObject newRoad = null;

        switch ((int)roadType)
        {
            case 0:
                newRoad = PrefabUtility.InstantiatePrefab(collectibleRoad) as GameObject;
                _newRoadPosition = new Vector3(lastRoadTransform.position.x / 2, lastRoadTransform.position.y,
                    lastRoadTransform.position.z + emptyRoad.GetComponent<BoxCollider>().size.z);
                break;
            case 1: //Empty
                newRoad = PrefabUtility.InstantiatePrefab(emptyRoad) as GameObject;
                _newRoadPosition = new Vector3(lastRoadTransform.position.x / 2, lastRoadTransform.position.y,
                    lastRoadTransform.position.z + emptyRoad.GetComponent<BoxCollider>().size.z);
                break;
            case 2: //Car
                newRoad = PrefabUtility.InstantiatePrefab(carRoad) as GameObject;
                _newRoadPosition = new Vector3(lastRoadTransform.position.x / 2, lastRoadTransform.position.y,
                    lastRoadTransform.position.z + carRoad.GetComponent<BoxCollider>().size.z);
                break;
            case 3: //Turret
                newRoad = PrefabUtility.InstantiatePrefab(turretRoad) as GameObject;
                _newRoadPosition = new Vector3(lastRoadTransform.position.x / 2, lastRoadTransform.position.y,
                    lastRoadTransform.position.z + turretRoad.GetComponent<BoxCollider>().size.z);
                break;
            case 4: //Drone
                newRoad = PrefabUtility.InstantiatePrefab(droneRoad) as GameObject;
                _newRoadPosition = new Vector3(lastRoadTransform.position.x / 2, lastRoadTransform.position.y,
                    lastRoadTransform.position.z + droneRoad.GetComponent<BoxCollider>().size.z);
                break;
            default:
                Debug.Log("Could not spawn road!");
                break;
        }

        ChangeTransform(newRoad);
    }

    [ContextMenu("Add Collectible Road")]
    void AddCollectibleRoad()
    {
        AddRoadPrefab(RoadType.Collectible);
    }
    
    [ContextMenu("Add Empty Road")]
    void AddEmptyRoad()
    {
        AddRoadPrefab(RoadType.Empty);
    }

    [ContextMenu("Add Car Road")]
    void AddCarRoad()
    {
        AddRoadPrefab(RoadType.Car);
    }

    [ContextMenu("Add Turret Road")]
    void AddTurretRoad()
    {
        AddRoadPrefab(RoadType.Turret);
    }

    [ContextMenu("Add Drone Road")]
    void AddDroneRoad()
    {
        AddRoadPrefab(RoadType.Drone);
    }

    [ContextMenu("Generate A Level")]
    private void GenerateLevel()
    {
        //int roadAmount = collectibleAmount * collectibleInterval + collectibleAmount;
        
        int roadTypeCount = Enum.GetNames(typeof(RoadType)).Length;     //GetNames is 10x faster than GetValues

        for (int i = 0; i < collectibleAmount; i++)
        {
            for (int j = 0; j < collectibleInterval; j++)
            {
                AddRoadPrefab((RoadType)Random.Range(1, roadTypeCount)); 
            } 
            AddRoadPrefab(RoadType.Collectible);
        }
    }

    private void Start()
    {
    }
   */
}
