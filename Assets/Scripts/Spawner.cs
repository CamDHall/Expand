using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Wall
    // public Walls walls;

    public GameObject shapeBar;
    List<GameObject> currentShapeBars;
    public List<GameObject> filledShapeBars;
    
    // Shapes
    public Shapes shapes;
    public Goals goals;
    public static int shapeChoice = 0;

    // Powerups
    public GameObject freezePower, explodePower, expandPower;
    float powerUpTimer, lowPowerLimit = 9f, highPowerLimit = 12f;
    int powerUpCounter = 0;

    float gravityModifier = 1.001f;
    float lowGravityLimit = 0.09f, highGravityLimit = 0.1f;
    
    // Misc Timer
    float shapeTimer, goalTimer;
    public float timerProgress = 0.99f, goalTimerProgress = 0.9999f;
    float lowLimit = 6, highLimit = 9;
    float goalTimerLow = 0.5f, goalTimerHigh = 0.8f, goalMultiplierTime;

    void Start () {
        shapeTimer = Time.timeSinceLevelLoad + 1f;
        goalTimer = Time.timeSinceLevelLoad + 2f;

        shapeChoice = 0;

        Instantiate(shapeBar);
    }

    void Update() {
        if (LevelManager.numFilled == ShapeBar.barHeight)
        {
            SpawnShapeBar();
            LevelManager.numFilled = 0;
        }

        // Shapes
        if (shapeTimer < Time.timeSinceLevelLoad)
        {
            shapeChoice = Random.Range(0, 3);
            shapes.GenerateShape();
            shapeTimer = Time.timeSinceLevelLoad + Random.Range(lowLimit, highLimit);
        }

        // Goals
        if(goalTimer < Time.timeSinceLevelLoad)
        {
            goals.Goal();
            goalMultiplierTime = Time.timeSinceLevelLoad / Random.Range(65f, 75f);
            goalTimer = Time.timeSinceLevelLoad + Random.Range(goalTimerLow / goalMultiplierTime, goalTimerHigh / goalMultiplierTime);
        }

        // Powerups
        if(powerUpTimer < Time.timeSinceLevelLoad)
        {

        }
    }

    void SpawnShapeBar()
    {
        currentShapeBars = new List<GameObject> (GameObject.FindGameObjectsWithTag("ShapeBar"));
        for (int i = 0; i < currentShapeBars.Count; i++)
        {
            currentShapeBars[i].transform.position = new Vector3(transform.position.x - (i + 1), currentShapeBars[i].transform.position.y, transform.position.z);
            filledShapeBars.Add(currentShapeBars[i]);
        }
        Instantiate(shapeBar);
        ShapeBar.spawnNewBar = false;
        currentShapeBars.Clear();
    }
}
