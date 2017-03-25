using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Image circleFill, squareFill, triangleFill;

    public static Vector3 circleShapePos;

    float redTimer;

    public void CircleUI()
    {
        redTimer = Time.timeSinceLevelLoad + 5f;
        if (LevelManager.circleFillLevel >= 1)
        {
            for (int i = 0; i < Shapes.circlePositions.Count; i++)
            {
                if (Shapes.circlePositions[i] == null)
                {
                    Debug.Log("HASN'T SPAWNED");
                }
                else
                {
                    Debug.Log(Shapes.circlePositions[i].x);
                }
            }
        }
        else
        {

        }
    }

    public void SquareUI()
    {
        if (LevelManager.squareFillLevel >= 1)
        {
            
        }
        else
        {
            
        }
    }

    public void TriangleUI()
    {
        if (LevelManager.triangleFillLevel >= 1)
        {
            
        }
        else
        {
            
        }
    }
}
