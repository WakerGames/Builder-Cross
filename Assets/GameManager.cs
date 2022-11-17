using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
   
    public delegate void RoadGeneration();
    public static  RoadGeneration generateRoad;


    
    private void Awake()
    {
        
    }
    void Start()
    {
        if (generateRoad != null)
            generateRoad();
    }

   
    void Update()
    {
        
    }
}
