using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class ObstacleData
{
    public static Dictionary<RoadType, int> obstacleRarity = new Dictionary<RoadType, int>();
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
        foreach (RoadType roadtype in Enum.GetValues(typeof(RoadType)))
        {
            //if (!obstacleRarity.ContainsKey(roadtype))
            //    obstacleRarity.Add(roadtype, 1024);
            obstacleRarity[roadtype] = 1024;
        }
        obstacleRarity[RoadType.Collectible] = 0;    //Set collectible to zero so collectibles do not spawn unintended
    }

    public static void ReduceChance(RoadType roadType)
    {
        obstacleRarity[roadType] /= _repeatReduceAmount;
    }

    public static void ResetObstacleDictionary()
    {

        if (obstacleRarity.ContainsKey(RoadType.Collectible))
        {
            obstacleRarity[RoadType.Collectible] = 0;
        }


        for (int i = 1; i < obstacleRarity.Count; i++)
        {
            obstacleRarity[obstacleRarity.ElementAt(i).Key] = 1024;
        }
    }
}