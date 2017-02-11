using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Wall
    public GameObject leftWall, rightWall;
    float wallX = 0, wallY = 0;
    Vector3 leftWallPos, rightWallPos;

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
    float lowLimit = 3f, highLimit = 5f;
    float goalTimerLow = 0.1f, goalTimerHigh = 0.5f, goalMultiplierTime;

	void Start () {
        obstacleTimer = Time.time + 1f;
        goalTimer = Time.time + 2f;
    }

    void Update() {

        if (obstacleTimer < Time.time)
        {
            if (lowLimit >= .1f)
            {
                lowLimit -= 0.1f;
            }

            if (highLimit >= 0.5f)
            {
                highLimit -= 0.1f;
            }
            Obstacle();
            obstacleTimer = Time.time + Random.Range(lowLimit, highLimit);
        }

        if(goalTimer < Time.time)
        {
            Goal();
            goalMultiplierTime = Time.time / 50f;
            goalTimer = Time.time + Random.Range(goalTimerLow / goalMultiplierTime, goalTimerHigh / goalMultiplierTime);
        }
    }

    void Obstacle()
    {
        // Gravity
        lowGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.001f, 0.05f);
        highGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.1f, .3f);
        gravity = Random.Range(lowGravityLimit, highGravityLimit);

        // Position
        wallX = Random.Range(-8.5f, 6f);
        wallY = Random.Range(0.7f, 2.5f);

        leftWallPos = new Vector3(wallX, transform.position.y, transform.position.z);
        rightWallPos = new Vector3(wallX + wallY, transform.position.y, transform.position.z);

        // Instantiate
        var left = Instantiate(leftWall, leftWallPos, leftWall.transform.rotation, transform);
        var right = Instantiate(rightWall, rightWallPos, rightWall.transform.rotation, transform);

        float Dist = (left.transform.position - right.transform.position).magnitude * 2.1f;

        Vector3 colSize = new Vector3(Dist, 1f, 0);

        left.GetComponent<BoxCollider2D>().size = colSize;
        right.GetComponent<BoxCollider2D>().size = new Vector3(Dist, 1f, 0);

        left.GetComponent<BoxCollider2D>().offset = new Vector3((colSize.x / 2) + 0.5f, 0, 0);
        right.GetComponent<BoxCollider2D>().offset = new Vector3((-1f * (colSize.x / 2)) - 0.5f, 0, 0);

        leftWall.GetComponent<Rigidbody2D>().gravityScale = gravity;
        rightWall.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    void Goal()
    {
        // Position
        goalPos = new Vector3(Random.Range(-8f, 8f), Random.Range(8f, 4.5f), 0);

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
