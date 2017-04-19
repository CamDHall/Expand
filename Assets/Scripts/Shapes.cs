using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour {
    
    // Shapes
    public GameObject hexagon, square, triangle;
    Vector3 newShapePos;
    float shapeXLowLimit, shapeXHighLimit, shapeYLowLimit, shapeYHighLimit;
    float gravity;
    static public List<GameObject> obstacleShapes;

    // Color Pieces
    Vector3 colorPiecePos;

    // Choices
    string lastChoice;
    int pieceChoice = 0, secondChoice;

	void Start () {
        shapeXLowLimit = -2.5f;
        shapeXHighLimit = 2.5f;
        shapeYLowLimit = 3;
        shapeYHighLimit = 6;

        obstacleShapes = new List<GameObject>();
	}

    public virtual void GenerateShape()
    {
        newShapePos = new Vector3(Random.Range(shapeXLowLimit, shapeXHighLimit), Random.Range(shapeYLowLimit, shapeYHighLimit), 0);

        gravity = Player.currentScale / 10;

        secondChoice = Random.Range(0, 5);
        if (lastChoice == "Hex")
        {
            if (secondChoice == 0)
            {
                SpawnHex();
            }
            else if (secondChoice <= 2)
            {
                SpawnSquare();
            }
            else
            {
                SpawnTriangle();
            }
        }
        else if (lastChoice == "Square")
        {
            if (secondChoice == 0)
            {
                SpawnSquare();
            }
            else if (secondChoice <= 2)
            {
                SpawnHex();
            }
            else
            {
                SpawnTriangle();
            }
        }
        else if (lastChoice == "Triangle")
        {
            if (secondChoice == 0)
            {
                SpawnTriangle();
            }
            else if (secondChoice <= 2)
            {
                SpawnSquare();
            }
            else
            {
                SpawnHex();
            }
        }
        else
        {
            if (Spawner.shapeChoice == 0)
            {
                SpawnHex();
            }
            else if (Spawner.shapeChoice == 1)
            {
                SpawnSquare();
            }
            else
            {
                SpawnTriangle();
            }
        }
    }
    
    void SpawnHex()
    {
        GameObject newHex = Instantiate(hexagon, newShapePos, Quaternion.identity);
        newHex.GetComponent<Rigidbody2D>().gravityScale = gravity;
        obstacleShapes.Add(newHex);
        TouchManager._hexes++;
        lastChoice = "Hex";
    } 

    void SpawnSquare()
    {
        GameObject newSquare = Instantiate(square, newShapePos, Quaternion.identity);
        newSquare.GetComponent<Rigidbody2D>().gravityScale = gravity;
        obstacleShapes.Add(newSquare);
        TouchManager._squares++;
        lastChoice = "Square";
    }

    void SpawnTriangle()
    {
        GameObject newTriangle = Instantiate(triangle, newShapePos, Quaternion.identity);
        newTriangle.GetComponent<Rigidbody2D>().gravityScale = gravity;
        obstacleShapes.Add(newTriangle);
        TouchManager._triangles++;
        lastChoice = "Triangle";
    }
}