using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    // Parent info
    GameObject Wall;

    public GameObject verticalWall, horizontalWall;

    float wallHeight = 0, wallWidth = 0;
    string lastPoint ="none";
    Vector3 lastPos;
    
	void Start () {
        Wall = new GameObject("Wall");
        Wall.transform.position = new Vector3(0, 3, 0);
	}

    public virtual void CreateWall()
    {
        wallHeight = Random.Range(6, 20);
        wallWidth = Random.Range(2.0f, 3.0f);

        // Left Wall
        GameObject leftWall = new GameObject("leftWall");
        leftWall.transform.SetParent(Wall.transform);
        leftWall.transform.position = new Vector3(-(wallWidth / 2), 3, 0);
        lastPos = leftWall.transform.position;

        // Right Wall
        GameObject rightWall = new GameObject("rightWall");
        rightWall.transform.SetParent(Wall.transform);

        // vars
        var _verticalYSize = verticalWall.GetComponent<SpriteRenderer>().bounds.size.y;
        var _verticalXSize = verticalWall.GetComponent<SpriteRenderer>().bounds.size.x;
        var _horizontalXSize = horizontalWall.GetComponent<SpriteRenderer>().bounds.size.x;
        var _horizontalYSize = horizontalWall.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 0; i < wallHeight; i++)
        {
            int choice = Random.Range(0, 6);

            // Vertical
            if (choice <= 2)
            {
                var leftVerticalCell = Instantiate(verticalWall);
                var rightVerticalCell = Instantiate(verticalWall);

                // Position based on last piece position
                if (lastPoint == "none")
                {
                    leftVerticalCell.transform.position = lastPos;
                }
                else if (lastPoint == "StayedVertical")
                {
                    leftVerticalCell.transform.position = new Vector3(lastPos.x, lastPos.y + _verticalYSize, 0);
                }
                else if (lastPoint == "LeftHorizontal")
                {
                    leftVerticalCell.transform.position = new Vector3(lastPos.x - ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_horizontalYSize / 2) + (_verticalYSize / 2)), 0);
                }
                else if (lastPoint == "RightHorizontal")
                {
                    leftVerticalCell.transform.position = new Vector3(lastPos.x + ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_horizontalYSize / 2) + (_verticalYSize / 2)), 0);
                }

                // Parenting, lastpoint
                // Left
                leftVerticalCell.transform.SetParent(leftWall.transform);
                lastPos = leftVerticalCell.transform.position;
                lastPoint = "StayedVertical";
                // Right
                rightVerticalCell.transform.position = new Vector3(leftVerticalCell.transform.position.x + (wallWidth), leftVerticalCell.transform.position.y, 0);
                rightVerticalCell.transform.SetParent(rightWall.transform);
            }

            // Move left
            else if (choice > 2 && choice <= 4)
            {
                var leftHorizontalLeftCell = Instantiate(horizontalWall);
                var leftHorizontalRightCell = Instantiate(horizontalWall);

                // Position based on last piece position
                if (lastPoint == "none")
                {
                    leftHorizontalLeftCell.transform.position = lastPos;
                }
                else if (lastPoint == "LeftHorizontal")
                {
                    leftHorizontalLeftCell.transform.position = new Vector3(lastPos.x - (_horizontalXSize), lastPos.y, 0);
                }
                else if (lastPoint == "StayedVertical")
                {
                    leftHorizontalLeftCell.transform.position = new Vector3(lastPos.x - ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_verticalYSize / 2) + (_horizontalYSize / 2)), 0);
                }
                else if (lastPoint == "RightHorizontal")
                {
                    leftHorizontalLeftCell.transform.position = new Vector3(lastPos.x, lastPos.y + (_horizontalYSize), 0);
                }

                // Parenting, lastpoint
                leftHorizontalLeftCell.transform.SetParent(leftWall.transform);
                lastPos = leftHorizontalLeftCell.transform.position;
                lastPoint = "LeftHorizontal";
                // Right
                leftHorizontalRightCell.transform.position = new Vector3(leftHorizontalLeftCell.transform.position.x + wallWidth, leftHorizontalLeftCell.transform.position.y, 0);
                leftHorizontalRightCell.transform.SetParent(rightWall.transform);
            }

            // Move Right
            else
            {
                var rightHorizontalLeftCell = Instantiate(horizontalWall);
                var rightHorizontalRightCell = Instantiate(horizontalWall);

                if (lastPoint == "none")
                {
                    rightHorizontalLeftCell.transform.position = lastPos;
                }
                else if (lastPoint == "RightHorizontal")
                {
                    rightHorizontalLeftCell.transform.position = new Vector3(lastPos.x + (_horizontalXSize), lastPos.y, 0);
                }
                else if (lastPoint == "StayedVertical")
                {
                    rightHorizontalLeftCell.transform.position = new Vector3(lastPos.x + ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_verticalYSize / 2) + (_horizontalYSize / 2)), 0);
                }
                else if (lastPoint == "LeftHorizontal")
                {
                    rightHorizontalLeftCell.transform.position = new Vector3(lastPos.x, lastPos.y + (_horizontalYSize), 0);
                }

                // Parenting, lastpoint
                rightHorizontalLeftCell.transform.SetParent(leftWall.transform);
                lastPos = rightHorizontalLeftCell.transform.position;
                lastPoint = "RightHorizontal";
                // Right
                rightHorizontalRightCell.transform.position = new Vector3(rightHorizontalLeftCell.transform.position.x + wallWidth, rightHorizontalLeftCell.transform.position.y, 0);
                rightHorizontalRightCell.transform.SetParent(rightWall.transform);
            }

        }
    }
}
