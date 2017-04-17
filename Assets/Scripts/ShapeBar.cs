using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBar : MonoBehaviour {

    public GameObject greyHex, greySquare, greyTriangle;
    int numberOfBars = 0; 
    public static int barHeight;
    Vector2 Pos;
    public static List<GameObject> shapeColorPieces;
    public static bool spawnNewBar = false;

	void Start () {
        numberOfBars++;
        shapeColorPieces = new List<GameObject>();
        spawnNewBar = false;

        // Bar height
        if(numberOfBars <= 3 )
        {
            barHeight = 3;
        } else
        {
            barHeight = 5;
        }

        for(int i = 0; i < barHeight; i++)
        {
            Pos = new Vector2(-2.5f, -4.5f + (i * 0.75f));
            int choice = Random.Range(0, 3);

            if (choice == 0)
            {
                var hexShape = Instantiate(greyHex, Pos, Quaternion.identity);
                hexShape.transform.SetParent(transform);
                shapeColorPieces.Add(hexShape);
            }
            else if (choice == 1)
            {
                var squareShape = Instantiate(greySquare, Pos, Quaternion.identity);
                squareShape.transform.SetParent(transform);
                shapeColorPieces.Add(squareShape);
            }
            else
            {
                var triangleShape = Instantiate(greyTriangle, Pos, Quaternion.identity);
                triangleShape.transform.SetParent(transform);
                shapeColorPieces.Add(triangleShape);
            }
        }
	}
}
