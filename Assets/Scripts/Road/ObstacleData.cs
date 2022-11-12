using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class ObstacleData
{
    public static Dictionary<string, int> obstacleRarity = new Dictionary<string, int>();
    private static int _repeatReduceAmount = 5; //Chance value is divided by this amount

    public enum RoadType
    {
        Collectible,
        Empty,
        Turret,
        BearTrap,
        StickyLiquid,
        SpinningBlades,
        Mine,
        Spikes,
        Attacker,
        Barrier,
        Zombie
    }

    public static void InitializeObstacleDictionary()
    {
        foreach (var roadName in Enum.GetNames(typeof(RoadType)))
        {
            if (!obstacleRarity.ContainsKey(roadName))
                obstacleRarity.Add(roadName, 1000);
        }

        obstacleRarity[obstacleRarity.ElementAt(0).Key] = 0;    //Set collectible to zero so collectibles do not spawn unintended
    }

    public static void ReduceChance(RoadType roadType)
    {
        if (obstacleRarity[Enum.GetName(typeof(RoadType), roadType)] != null)
            obstacleRarity[Enum.GetName(typeof(RoadType), roadType)] /= _repeatReduceAmount;
    }

    public static void ResetObstacleDictionary()
    {
        try
        {
            if (!obstacleRarity.ElementAt(0).IsUnityNull())
            {
                obstacleRarity[obstacleRarity.ElementAt(0).Key] = 0;
            }
        }
        catch (ArgumentOutOfRangeException)
        {

            //throw;
        }
        
        
        
        for (int i = 1; i < obstacleRarity.Count; i++)
        {
            obstacleRarity[obstacleRarity.ElementAt(i).Key] = 100;
        }
    }
}