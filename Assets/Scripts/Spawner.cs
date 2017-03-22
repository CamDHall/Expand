using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Wall
    // public Walls walls;

    // Goals
    public GameObject sphere;
    public static Vector3 goalPos;
    Color goalColor;

    // Gravity
    float gravity, goalGravity = 1.01f;
    float gravityModifier = 1.001f;
    float lowGravityLimit = 0.09f, highGravityLimit = 0.1f;
    
    // Timer
    float obstacleTimer, goalTimer;
    public float timerProgress = 0.99f, goalTimerProgress = 0.9999f;
    float lowLimit = 6f, highLimit = 10f;
    float goalTimerLow = 0.1f, goalTimerHigh = 0.5f, goalMultiplierTime;

	void Start () {
        obstacleTimer = Time.timeSinceLevelLoad + 1f;
        goalTimer = Time.timeSinceLevelLoad + 2f;
    }

    void Update() {
        if(obstacleTimer < Time.timeSinceLevelLoad)
        {
            // walls.CreateWall();
            obstacleTimer = Time.timeSinceLevelLoad + Random.Range(lowLimit, highLimit);
        }

        if(goalTimer < Time.timeSinceLevelLoad)
        {
            Goal();
            goalMultiplierTime = Time.timeSinceLevelLoad / Random.Range(50f, 60f);
            goalTimer = Time.timeSinceLevelLoad + Random.Range(goalTimerLow / goalMultiplierTime, goalTimerHigh / goalMultiplierTime);
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
}
