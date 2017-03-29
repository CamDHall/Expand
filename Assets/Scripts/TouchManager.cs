using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Image hexagonFill, squareFill, triangleFill;
    public GameObject hexagonPiece, squarePiece, trianglePiece;

    // Shape Information
    public static Vector3 circleShapePos, squareShapePos, triangleShapePos;
    public static int _hexes, _squares, _triangles;

    float redTimer;

    void Start()
    {
        circleShapePos = new Vector3(6, 0, 0);
        squareShapePos = new Vector3(6, 0, 0);
        triangleShapePos = new Vector3(6, 0, 0);
        _hexes = 0;
        _squares = 0;
        _triangles = 0;
    }

    public void HexagonUI()
    {
        if (LevelManager.hexagonFillLevel >= 1)
        {
            if(_hexes > 0)
            {
                GameObject deleteCircle = GameObject.FindGameObjectWithTag("Circle");
                deleteCircle.transform.DetachChildren();
                Destroy(deleteCircle);
            } else
            {
                // Animation
            }
        } else
        {
            // Animation
        }
    }

    public void SquareUI()
    {
        if (LevelManager.squareFillLevel >= 1)
        {
            if (_squares > 0)
            {
                GameObject deleteSquare = GameObject.FindGameObjectWithTag("Square");
                deleteSquare.transform.DetachChildren();
                Destroy(deleteSquare);
            } else
            {
                // Animation
            }
        }
        else
        {
            // Animation
        }
    }

    public void TriangleUI()
    {
        if (LevelManager.triangleFillLevel >= 1)
        {
            if(_triangles > 0)
            {
                GameObject deleteTriangle = GameObject.FindGameObjectWithTag("Triangle");
                deleteTriangle.transform.DetachChildren();
                Destroy(deleteTriangle);
            }   else
            {
                // Animation
            }
        }
        else
        {
            // Animation
        }
    }
}
