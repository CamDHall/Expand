﻿using System.Collections;
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
    public static int shapeChoice = 0;

    // Powerups
    public GameObject freezePower, explodePower, expandPower;
    float powerUpTimer, lowPowerLimit = 9f, highPowerLimit = 12f;
    int powerUpCounter = 0;

    // Goals
    public GameObject sphere;
    public static Vector3 goalPos;
    Color goalColor;

    // Gravity
    float gravity, goalGravity = 1.01f;
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
            Goal();
            goalMultiplierTime = Time.timeSinceLevelLoad / Random.Range(65f, 75f);
            goalTimer = Time.timeSinceLevelLoad + Random.Range(goalTimerLow / goalMultiplierTime, goalTimerHigh / goalMultiplierTime);
        }

        // Powerups
        if(powerUpTimer < Time.timeSinceLevelLoad)
        {

        }
    }

    void Goal()
    {
        // Position
        goalPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(3.75f, 7f), 0);

        // Instantiate
        GameObject circle = Instantiate(sphere, transform);
        var scale = Random.Range(0.75f, 3f);
        sphere.transform.localScale = new Vector3(scale, scale,0);
        sphere.transform.position = goalPos;

        // Color
        goalColor = new Color(Random.value, Random.value, Random.value, 1f);
        circle.GetComponent<SpriteRenderer>().material.color = goalColor;

        // Gravity
        sphere.GetComponent<Rigidbody2D>().gravityScale = goalGravity / (1 + scale);
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
