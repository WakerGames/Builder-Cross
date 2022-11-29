using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;
using RoadType = ObstacleData.RoadType;

[ExecuteAlways]
public class RoadGenerator : MonoBehaviour
{
    public static RoadGenerator Instance { get; set; }

    [SerializeField, CanBeNull] private Transform lastRoadTransform;
    [SerializeField] private GameObject collectibleRoad;        //Can be turned into a class
    [SerializeField] private GameObject emptyRoad;
    [SerializeField] private GameObject turretRoad;
    [SerializeField] private GameObject bearTrapRoad;
    [SerializeField] private GameObject stickyLiquidRoad;
    [SerializeField] private GameObject spinningBladeRoad;
    [SerializeField] private GameObject mineRoad;
    [SerializeField] private GameObject spikeRoad;
    [SerializeField] private GameObject attackerRoad;
    [SerializeField] private GameObject barrierRoad;
    [SerializeField] private GameObject zombieRoad;

    [SerializeField] private List<GameObject> specialRoads;

    private Dictionary<RoadType, GameObject> roadTypeDict = new();

    private Vector3 _newRoadPosition;



    [Header("Level Generation")]
    [SerializeField, Min(1)]
    private int collectibleAmount;

    [SerializeField, Min(1)] private int collectibleInterval;

    private void Awake() //Singleton
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

    private void OnEnable()
    {
       
        
        roadTypeDict[RoadType.Collectible] = collectibleRoad;
        roadTypeDict[RoadType.Empty] = emptyRoad;
        roadTypeDict[RoadType.Turret] = turretRoad;
        roadTypeDict[RoadType.BearTrap] = bearTrapRoad;
        roadTypeDict[RoadType.StickyLiquid] = stickyLiquidRoad;
        roadTypeDict[RoadType.SpinningBlades] = spinningBladeRoad;
        roadTypeDict[RoadType.Mine] = mineRoad;
        roadTypeDict[RoadType.Spikes] = spikeRoad;
        roadTypeDict[RoadType.Attacker] = attackerRoad;
        roadTypeDict[RoadType.Barrier] = barrierRoad;
        roadTypeDict[RoadType.Zombie] = zombieRoad;
    }
    

    private void CreateRoad(GameObject road)
    {
        GameObject createdRoad = Instantiate(road);    /*PrefabUtility.InstantiatePrefab(road) as GameObject;*/
        _newRoadPosition = new Vector3(lastRoadTransform.position.x, lastRoadTransform.position.y,
            lastRoadTransform.position.z + emptyRoad.GetComponent<BoxCollider>().size.z);

        if (createdRoad != null)
        {
            createdRoad.transform.position = _newRoadPosition;
            createdRoad.transform.parent = this.transform;

            lastRoadTransform = createdRoad.transform;
        }
    }

    void AddRoadPrefab(RoadType roadType)
    {
        if (lastRoadTransform == null)
        {
            var player = GameObject.FindWithTag("Player");
            lastRoadTransform = player.GetComponent<Transform>();
            lastRoadTransform.position = new Vector3(lastRoadTransform.position.x, (lastRoadTransform.position.y - player.GetComponent<BoxCollider>().size.y / 2), lastRoadTransform.position.z);
        }

        //Create a dictionary with enum keys and values 

        CreateRoad(roadTypeDict[roadType]);

    }

    void AddRandomSpecialRoad()
    {
        if (specialRoads.Count != 0)
        {
            CreateRoad(specialRoads[Random.Range(0, specialRoads.Count)]);
        }
    }

    void AddSpecialRoad(int roadIndex)
    {
        if (specialRoads.Count != 0)
        {
            CreateRoad(specialRoads[roadIndex]);
        }
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

    [ContextMenu("Add Turret Road")]
    void AddTurretRoad()
    {
        AddRoadPrefab(RoadType.Turret);
    }

    [ContextMenu("Add Bear Trap Road")]
    void AddBearTrapRoad()
    {
        AddRoadPrefab(RoadType.BearTrap);
    }

    [ContextMenu("Add Sticky Road")]
    void AddStickyRoad()
    {
        AddRoadPrefab(RoadType.StickyLiquid);
    }

    [ContextMenu("Add Spinning Blade Road")]
    void AddSpinningBladeRoad()
    {
        AddRoadPrefab(RoadType.SpinningBlades);
    }

    [ContextMenu("Add Mine Road")]
    void AddMineRoad()
    {
        AddRoadPrefab(RoadType.Mine);
    }

    [ContextMenu("Add Spike Road")]
    void AddSpikeRoad()
    {
        AddRoadPrefab(RoadType.Spikes);
    }

    [ContextMenu("Add Attacker Road")]
    void AddAttackerRoad()
    {
        AddRoadPrefab(RoadType.Attacker);
    }

    [ContextMenu("Add Barrier Road")]
    void AddBarrierTrapRoad()
    {
        AddRoadPrefab(RoadType.Barrier);
    }

    [ContextMenu("Add Zombie Road")]
    void AddZombieRoad()
    {
        AddRoadPrefab(RoadType.Zombie);
    }
    
    [ContextMenu("Add Custom-1 Road")]
    void AddCustom1Road()
    {
        AddSpecialRoad(0);
    }
    
    [ContextMenu("Add Custom-2 Road")]
    void AddCustom2Road()
    {
        AddSpecialRoad(1);
    }
    
    [ContextMenu("Add Custom-3 Road")]
    void AddCustom3Road()
    {
        AddSpecialRoad(2);
    }
    
    [ContextMenu("Add Custom-4 Road")]
    void AddCustom4Road()
    {
        AddSpecialRoad(3);
    }
    
    [ContextMenu("Add Custom-5 Road")]
    void AddCustom5Road()
    {
        AddSpecialRoad(4);
    }
    
    [ContextMenu("Add Custom-6 Road")]
    void AddCustom6Road()
    {
        AddSpecialRoad(5);
    }
    
    [ContextMenu("Add Custom-7 Road")]
    void AddCustom7Road()
    {
        AddSpecialRoad(6);
    }
    
    [ContextMenu("Add Custom-8 Road")]
    void AddCustom8Road()
    {
        AddSpecialRoad(7);
    }
    
    [ContextMenu("Add Custom-9 Road")]
    void AddCustom9Road()
    {
        AddSpecialRoad(8);
    }
    
    [ContextMenu("Add Custom-10 Road")]
    void AddCustom10Road()
    {
        AddSpecialRoad(9);
    }
    
    [ContextMenu("Add Custom-11 Road")]
    void AddCustom11Road()
    {
        AddSpecialRoad(10);
    }
    
    [ContextMenu("Add Custom-12 Road")]
    void AddCustom12Road()
    {
        AddSpecialRoad(11);
    }
    
    [ContextMenu("Add Custom-13 Road")]
    void AddCustom13Road()
    {
        AddSpecialRoad(12);
    }
    
    [ContextMenu("Add Custom-14 Road")]
    void AddCustom14Road()
    {
        AddSpecialRoad(13);
    }
    
    [ContextMenu("Add Custom-15 Road")]
    void AddCustom15Road()
    {
        AddSpecialRoad(14);
    }
    
    [ContextMenu("Add Custom-16 Road")]
    void AddCustom16Road()
    {
        AddSpecialRoad(15);
    }
    
    [ContextMenu("Add Custom-17 Road")]
    void AddCustom17Road()
    {
        AddSpecialRoad(16);
    }
    
    

    [ContextMenu("Generate A Level")]
    private void GenerateLevel()
    {
        //roadAmount = collectibleAmount * collectibleInterval + collectibleAmount;

        int roadTypeCount = Enum.GetNames(typeof(RoadType)).Length; //GetNames is 10x faster than GetValues

        for (int i = 0; i < collectibleAmount; i++)
        {
            for (int j = 0; j < collectibleInterval; j++)
            {
                AddRoadPrefab((RoadType)Random.Range(1, roadTypeCount));
                AddRandomSpecialRoad();   //Special
            }

            AddRoadPrefab(RoadType.Collectible);
        }
    }

    private int CalculateWeight()
    {
        int totalWeight = 0;
        foreach (var pair in ObstacleData.obstacleRarity)
        {
            totalWeight += pair.Value;
        }

        return totalWeight;
    }

    [ContextMenu("Generate Weighted Level")]
    private void GenerateWeightedLevel()
    {
        ObstacleData.InitializeObstacleDictionary();
        //int roadTypeCount = Enum.GetNames(typeof(RoadType)).Length;

        int totalWeight = CalculateWeight();

        for (int i = 0; i < collectibleAmount; i++)
        {
            for (int j = 0; j < collectibleInterval; j++)
            {
                int randomNumber = Random.Range(0, totalWeight + 1);
                int pointer = 0; //To go through the pie chart. This sums the values

                for (int k = 0; k < ObstacleData.obstacleRarity.Count; k++)
                {
                    if (randomNumber <= ObstacleData.obstacleRarity.ElementAt(k).Value + pointer)
                    {
                        AddRoadPrefab((RoadType)k);
                        AddRandomSpecialRoad();   //Special
                        ObstacleData.ReduceChance((RoadType)k);
                        totalWeight = CalculateWeight();
                        break;
                    }

                    pointer += ObstacleData.obstacleRarity.ElementAt(k).Value; //Summing action
                }
            }

            AddRoadPrefab(RoadType.Collectible);
        }
    }

    [ContextMenu("Clear Levels")]
    private void ClearAllLevels()
    {
        foreach (var child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child != null &&
                child.gameObject != this.gameObject) //WILL destroy itself if you dont check if child is itself
                DestroyImmediate(child.gameObject);
        }

        ObstacleData.ResetObstacleDictionary();
    }
}