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
    public static int fairChoice = 0;

    // Powerups
    public PowerUpManager manager;
    public GameObject freezePower, explodePower, expandPower;
    float powerUpTimer, lowPowerLimit = 15f, highPowerLimit = 20f;
    int powerUpCounter = 0;

    float gravityModifier = 1.001f;
    float lowGravityLimit = 0.09f, highGravityLimit = 0.1f;
    
    // Misc Timer
    float shapeTimer, goalTimer;
    public float timerProgress = 0.99f, goalTimerProgress = 0.9999f;
    float shapeTimerLow = 5f, shapeTimerHigh = 8f, shapeMultiplierTime = 1f; // Shape Timer
    float goalTimerLow = 0.6f, goalTimerHigh = 0.9f, goalMultiplierTime; // Goal Timer

    void Start () {
        shapeTimer = Time.timeSinceLevelLoad + 1f;
        goalTimer = Time.timeSinceLevelLoad + 2f;

        fairChoice = 0;

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
            fairChoice = Random.Range(0, 3);
            shapes.GenerateShape();
            shapeMultiplierTime += Time.deltaTime;
            shapeTimer = Time.timeSinceLevelLoad + Random.Range(shapeTimerLow / (shapeMultiplierTime * 0.8f), shapeTimerHigh / shapeMultiplierTime);
        }

        // Goals
        if(goalTimer < Time.timeSinceLevelLoad)
        {
            goals.Goal();
            goalMultiplierTime = Time.timeSinceLevelLoad / Random.Range(45, 60);
            goalTimer = Time.timeSinceLevelLoad + Random.Range(goalTimerLow / goalMultiplierTime, goalTimerHigh / goalMultiplierTime);
        }

        // Powerups
        if(powerUpTimer < Time.timeSinceLevelLoad)
        {
            if (!(PowerUpManager.freezePowerups >= 3 && PowerUpManager.damagePowerups >= 3 && PowerUpManager.boostPowerups >= 3))
            {
                manager.GeneratePowerUp();
            }
            powerUpTimer = Time.timeSinceLevelLoad + Random.Range(lowPowerLimit, highPowerLimit);
        }
    }

    void SpawnShapeBar()
    {
        currentShapeBars = new List<GameObject> (GameObject.FindGameObjectsWithTag("ShapeBar"));
        for (int i = 0; i < currentShapeBars.Count; i++)
        {
            currentShapeBars[i].transform.position = new Vector3(currentShapeBars[i].transform.position.x - 3, currentShapeBars[i].transform.position.y, transform.position.z);
            filledShapeBars.Add(currentShapeBars[i]);
        }
        Instantiate(shapeBar);
        ShapeBar.spawnNewBar = false;
        currentShapeBars.Clear();
    }
}
