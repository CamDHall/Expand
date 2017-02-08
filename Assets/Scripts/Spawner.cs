using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Wall
    public GameObject leftWall, rightWall;
    float wallX = 0, wallY = 0;
    Vector3 leftWallPos, rightWallPos;

    // Goals
    public GameObject leftGoal, rightGoal;
    public static Vector3 leftGoalPos, rightGoalPos;
    float goalX = 0;

    // Gravity
    float gravity, goalGravity;
    float gravityModifier = 1.001f;
    float lowGravityLimit = 0.09f, highGravityLimit = 0.1f, goalLowGravityLimit = 0.09f, goalHighGravityLimit = 0.1f;
    
    // Timer
    float obstacleTimer, goalTimer;
    public float timerProgress = 0.99f, goalTimerProgress = 0.9999f;
    float lowLimit = 3f, highLimit = 5f;
    float goalTimerLow = 6f, goalTimerHigh = 12f;

    // Collider
    BoxCollider2D leftCollider, rightCollider;
    float Dist;

	void Start () {
        obstacleTimer = Time.time + 1f;
        goalTimer = Time.time + 6f;
    }

    void Update() {

        if (obstacleTimer < Time.time)
        {
            Obstacle();
            obstacleTimer = Time.time + Random.Range(lowLimit, highLimit);
        }

        if(goalTimer < Time.time)
        {
            Goal();
            goalTimer = Time.time + Random.Range(goalTimerLow, goalTimerHigh);
        }
    }

    void Obstacle()
    {
        // Gravity
        lowGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.001f, 0.05f);
        highGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.1f, .3f);
        gravity = Random.Range(lowGravityLimit, highGravityLimit);

        // Position
        wallX = Random.Range(-2.2f, 1f);
        wallY = Random.Range(0.8f, 2f);

        leftWallPos = new Vector3(wallX, transform.position.y, transform.position.z);
        rightWallPos = new Vector3(wallX + wallY, transform.position.y, transform.position.z);

        // Instantiate
        Instantiate(leftWall, leftWallPos, transform.rotation, transform);
        Instantiate(rightWall, rightWallPos, transform.rotation, transform);

        leftWall.GetComponent<Rigidbody2D>().gravityScale = gravity;
        rightWall.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    void Goal()
    {
        // Gravity
        goalLowGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.1f, 0.3f);
        goalHighGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.3f, .75f);
        goalGravity = Random.Range(lowGravityLimit, highGravityLimit);

        // Position
        leftGoalPos = new Vector3(Random.Range(-2f, -.5f), 5.75f, transform.position.z);
        rightGoalPos = new Vector3(Random.Range(.5f, 2f), 5.75f, transform.position.z);

        // Instantiate
        Instantiate(leftGoal, leftGoalPos, transform.rotation);
        Instantiate(rightGoal, rightGoalPos, transform.rotation);

        leftGoal.GetComponent<Rigidbody2D>().gravityScale = goalGravity;
        rightGoal.GetComponent<Rigidbody2D>().gravityScale = goalGravity;

        // Collider
        leftCollider = leftGoal.GetComponent<BoxCollider2D>();
        rightCollider = rightGoal.GetComponent<BoxCollider2D>();

        Dist = rightCollider.bounds.center.x - leftCollider.bounds.center.x;
        Debug.Log(Dist);
        leftCollider.size = new Vector3(Dist * 2, 1, 1);
        leftCollider.offset = new Vector3(Dist, 0, 0);
    }
}
