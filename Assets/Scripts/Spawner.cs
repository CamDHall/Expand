using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Wall
    public GameObject leftWall, rightWall;
    float wallX = 0, wallY = 0;
    Vector3 leftWallPos, rightWallPos;
    public GameObject wallCell;
    float cellHeight;

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
        cellHeight = wallCell.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        Debug.Log(cellHeight);
    }

    void Update() {

        /* if (obstacleTimer < Time.timeSinceLevelLoad)
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
            obstacleTimer = Time.timeSinceLevelLoad + Random.Range(lowLimit, highLimit);
        } */

        if(obstacleTimer < Time.timeSinceLevelLoad)
        {
            Obstacle();
            obstacleTimer = Time.timeSinceLevelLoad + Random.Range(lowLimit, highLimit);
        }

        if(goalTimer < Time.timeSinceLevelLoad)
        {
            Goal();
            goalMultiplierTime = Time.timeSinceLevelLoad / Random.Range(50f, 60f);
            goalTimer = Time.timeSinceLevelLoad + Random.Range(goalTimerLow / goalMultiplierTime, goalTimerHigh / goalMultiplierTime);
        }
    }

    void Obstacle()
    {
        // Parent Wall
        GameObject Wall = new GameObject("Wall");
        Wall.transform.position = new Vector3(0, 5, 0);
        int wallHeight = Random.Range(5, 12);
        int wallWidth = Random.Range(1, 5);
        // Left Wall
        GameObject leftWall = new GameObject("leftWall");
        leftWall.transform.position = new Vector3(-1 * (wallWidth/2), Wall.transform.position.y, transform.position.z);

        leftWall.transform.SetParent(Wall.transform);

        for(int i = 0; i < wallHeight; i++)
        {
            float cellXPos = leftWall.transform.position.x;

            int choice = Random.Range(0, 4);
            if(choice == 2)
            {
                cellXPos -= cellHeight;
            }

            if(choice == 1)
            {
                cellXPos += cellHeight;
            }
            

            Vector3 wallCellPos = new Vector3(cellXPos, leftWall.transform.position.y + (i * cellHeight), wallCell.transform.position.z);
            var cell = Instantiate(wallCell);
            cell.transform.SetParent(leftWall.transform);
            cell.transform.position = wallCellPos;
        }

        /*
        // Gravity
        lowGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.001f, 0.05f);
        highGravityLimit = Mathf.Clamp((gravityModifier / Player.currentScale), 0.1f, .3f);
        gravity = Random.Range(lowGravityLimit, highGravityLimit);

        // Position
        wallX = Random.Range(-2.5f, 2f);
        wallY = Random.Range(0.4f, 1f);

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
        */
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
