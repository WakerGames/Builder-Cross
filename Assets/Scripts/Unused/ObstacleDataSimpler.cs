using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDataSimpler : MonoBehaviour        //Change the name later
{
    public string roadName;
    public int weight;

    public static List<ObstacleDataSimpler> RoadPercentages;

    public ObstacleDataSimpler(string newRoadName, int newWeight)
    {
        roadName = newRoadName;
        weight = newWeight;
    }

    void InitializePercentages()
    {
        
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
