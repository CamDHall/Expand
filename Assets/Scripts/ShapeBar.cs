using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBar : MonoBehaviour {

    public GameObject greyHex, greySquare, greyTriangle;
    int numberOfBars, barHeight;
    Vector2 Pos;

	void Start () {
        if (LevelManager.level <= 3)
            numberOfBars = 1;
        else
            numberOfBars = LevelManager.level;

        if (LevelManager.level == 0)
            barHeight = 1;
        else if (LevelManager.level <= 2)
            barHeight = 2;
        else if (LevelManager.level <= 10)
            barHeight = 3;
        else if (LevelManager.level <= 25)
            barHeight = 4;
        else
            barHeight = 5;

        for(int i = 0; i < barHeight; i++)
        {
            Pos = new Vector2(-2.5f, -4.5f + i);
            int choice = Random.Range(0, 3);

            if (choice == 0)
                Instantiate(greyHex, Pos, Quaternion.identity);
            else if (choice == 1)
                Instantiate(greySquare, Pos, Quaternion.identity);
            else
                Instantiate(greyTriangle, Pos, Quaternion.identity);
        }
	}
	
	void Update () {
		
	}
}
