using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour {
    
    // Shapes
    public GameObject circle, square, triangle;
    Vector3 newShapePos;
    float shapeXLowLimit, shapeXHighLimit, shapeYLowLimit, shapeYHighLimit;

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

        if(shapeChoice == 0)
        {
            Instantiate(circle, newShapePos, Quaternion.identity);
        } else if(shapeChoice == 1)
        {
            Instantiate(square, newShapePos, Quaternion.identity);
        } else
        {
            Instantiate(triangle, newShapePos, Quaternion.identity);
        }
    } 
}
