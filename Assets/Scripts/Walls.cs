using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    // Parent info
    GameObject Wall;

    public GameObject verticalWall, horizontalWall;

    float wallHeight = 0;
    string lastPoint ="none";
    Vector3 lastPos;
    
	void Start () {
        Wall = new GameObject("Wall");
        Wall.transform.position = new Vector3(0, 3, 0);
	}

    public virtual void CreateWall()
    {
        wallHeight = Random.Range(6, 20);

        CreateLeftWall();

        
    }

    void CreateLeftWall()
    {
        GameObject leftWall = new GameObject("leftWall");
        leftWall.transform.SetParent(Wall.transform);

        // vars
        var _verticalYSize = verticalWall.GetComponent<SpriteRenderer>().bounds.size.y;
        var _verticalXSize = verticalWall.GetComponent<SpriteRenderer>().bounds.size.x;
        var _horizontalXSize = horizontalWall.GetComponent<SpriteRenderer>().bounds.size.x;
        var _horizontalYSize = horizontalWall.GetComponent<SpriteRenderer>().bounds.size.y;

        for(int i = 0; i < wallHeight; i++)
        {
            Debug.Log(verticalWall.GetComponent<SpriteRenderer>().bounds.size.x);
            int choice = Random.Range(0, 6);

            // Vertical
            if (choice <= 2)
            {
                var vertical = Instantiate(verticalWall);

                // Position based on last piece position
                if (lastPoint == "none")
                {
                    vertical.transform.position = new Vector3(0, 0);
                } else if(lastPoint == "StayedVertical")
                {
                    vertical.transform.position = new Vector3(lastPos.x, lastPos.y + _verticalYSize, 0);
                } else if(lastPoint == "LeftHorizontal")
                {
                    vertical.transform.position = new Vector3(lastPos.x - ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_horizontalYSize / 2) + (_verticalYSize / 2)), 0);
                } else if(lastPoint == "RightHorizontal")
                {
                    vertical.transform.position = new Vector3(lastPos.x + ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_horizontalYSize / 2) + (_verticalYSize / 2)), 0);
                }

                // Parenting, lastpoint
                vertical.transform.SetParent(leftWall.transform);
                lastPos = vertical.transform.position;
                lastPoint = "StayedVertical";
            }

            // Move left
            else if(choice > 2 && choice <= 4)
            {
                var leftHorizontal = Instantiate(horizontalWall);
                leftHorizontal.transform.position = new Vector3(0, 0);

                // Position based on last piece position
                if (lastPoint == "none")
                {
                    leftHorizontal.transform.position = new Vector3(0, 0);
                } else if (lastPoint == "LeftHorizontal")
                {
                    leftHorizontal.transform.position = new Vector3(lastPos.x - (_horizontalXSize), lastPos.y, 0);
                } else if (lastPoint == "StayedVertical")
                {
                    leftHorizontal.transform.position = new Vector3(lastPos.x - ((_horizontalXSize / 2) - (_verticalXSize / 2)), lastPos.y + ((_verticalYSize / 2) + (_horizontalYSize / 2)), 0);
                } else if(lastPoint == "RightHorizontal")
                {
                    leftHorizontal.transform.position = new Vector3(lastPos.x, lastPos.y + (_horizontalYSize), 0);
                }

                // Parenting, lastpoint
                leftHorizontal.transform.SetParent(leftWall.transform);
                lastPos = leftHorizontal.transform.position;
                lastPoint = "LeftHorizontal";
            }

            // Move Right
            else
            {
                var rightHorizontal = Instantiate(horizontalWall);
                if(lastPoint == "none")
                {
                    rightHorizontal.transform.position = new Vector3(0, 0);
                } else if(lastPoint == "RightHorizontal")
                {
                    rightHorizontal.transform.position = new Vector3(lastPos.x + (_horizontalXSize), lastPos.y, 0);
                } else if(lastPoint == "StayedVertical")
                {
                    rightHorizontal.transform.position = new Vector3(lastPos.x + ((_horizontalXSize / 2) - (_verticalXSize/2)), lastPos.y + ((_verticalYSize / 2) + (_horizontalYSize / 2)), 0);
                } else if(lastPoint == "LeftHorizontal")
                {
                    rightHorizontal.transform.position = new Vector3(lastPos.x, lastPos.y + (_horizontalYSize), 0);
                }

                // Parenting, lastpoint
                rightHorizontal.transform.SetParent(leftWall.transform);
                lastPos = rightHorizontal.transform.position;
                lastPoint = "RightHorizontal";
            }

        }
    }
}
