using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour {
    
    // Shapes
    public GameObject circle, square, triangle;
    Vector3 newShapePos;
    float shapeXLowLimit, shapeXHighLimit, shapeYLowLimit, shapeYHighLimit;

    // Color Pieces
    public GameObject colorPiecesPrefab;

    // Choices
    int shapeChoice = 0;

	void Start () {
        shapeXLowLimit = -2.5f;
        shapeXHighLimit = 2.5f;
        shapeYLowLimit = 3;
        shapeYHighLimit = 6;
	}
	
	void Update () {
		
	}

    public virtual void GenerateShape()
    {
        newShapePos = new Vector3(Random.Range(shapeXLowLimit, shapeXHighLimit), Random.Range(shapeYLowLimit, shapeYHighLimit), 0);
        shapeChoice = Random.Range(0, 3);

        float gravity = Player.currentScale / 10;

        if(shapeChoice == 0)
        {
            GameObject newCircle = Instantiate(circle, newShapePos, Quaternion.identity);
            newCircle.GetComponent<Rigidbody2D>().gravityScale = gravity;
        } else if(shapeChoice == 1)
        {
            GameObject newSquare = Instantiate(square, newShapePos, Quaternion.identity);
            newSquare.GetComponent<Rigidbody2D>().gravityScale = gravity;
        } else
        {
            GameObject newTriangle = Instantiate(triangle, newShapePos, Quaternion.identity);
            newTriangle.GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
    } 
}
