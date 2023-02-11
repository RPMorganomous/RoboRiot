using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    // Serialize to make it visible in the inspector
[System.Serializable]

// Create a class for the Robot
public class Robot
{
    //define traits
    public GameObject robotPrefab;

    // Create a constructor
    public Robot(GameObject robotPrefab)
    {
        this.robotPrefab = robotPrefab;
    }
}
