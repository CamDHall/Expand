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
    int pieceChoice = 0, choice;

	void Start () {
        shapeXLowLimit = -2.5f;
        shapeXHighLimit = 2.5f;
        shapeYLowLimit = 4.5f;
        shapeYHighLimit = 6;

        obstacleShapes = new List<GameObject>();
	}

    public void GenerateShape()
    {
        newShapePos = new Vector3(Random.Range(shapeXLowLimit, shapeXHighLimit), Random.Range(shapeYLowLimit, shapeYHighLimit), 0);

        gravity = Player.currentScale / 10;

        choice = Random.Range(0, 5);
        if (lastChoice == "Hex")
        {
            if (choice == 0)
            {
                SpawnHex();
            }
            else if (choice <= 2)
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
            if (choice == 0)
            {
                SpawnSquare();
            }
            else if (choice <= 2)
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
            if (choice == 0)
            {
                SpawnTriangle();
            }
            else if (choice <= 2)
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
            if (Spawner.fairChoice == 0)
            {
                SpawnHex();
            }
            else if (Spawner.fairChoice == 1)
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