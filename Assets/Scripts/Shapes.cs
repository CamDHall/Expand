﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour {
    
    // Shapes
    public GameObject hexagon, square, triangle;
    Vector3 newShapePos;
    float shapeXLowLimit, shapeXHighLimit, shapeYLowLimit, shapeYHighLimit;

    // Color Pieces
    public GameObject colorPiecesPrefab;
    Vector3 colorPiecePos;

    // Choices
    int pieceChoice = 0;

	void Start () {
        shapeXLowLimit = -2.5f;
        shapeXHighLimit = 2.5f;
        shapeYLowLimit = 3;
        shapeYHighLimit = 6;
	}

    public virtual void GenerateShape()
    {
        newShapePos = new Vector3(Random.Range(shapeXLowLimit, shapeXHighLimit), Random.Range(shapeYLowLimit, shapeYHighLimit), 0);

        float gravity = Player.currentScale / 10;

        if(Spawner.shapeChoice == 0)
        {
            GameObject newCircle = Instantiate(hexagon, newShapePos, Quaternion.identity);            
            newCircle.GetComponent<Rigidbody2D>().gravityScale = gravity;
            TouchManager._hexes++;
        } else if(Spawner.shapeChoice == 1)
        {
            GameObject newSquare = Instantiate(square, newShapePos, Quaternion.identity);
            newSquare.GetComponent<Rigidbody2D>().gravityScale = gravity;
            TouchManager._squares++;
        } else
        {
            GameObject newTriangle = Instantiate(triangle, newShapePos, Quaternion.identity);
            newTriangle.GetComponent<Rigidbody2D>().gravityScale = gravity;
            TouchManager._triangles++;
        }
    } 
}
