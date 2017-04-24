using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour {

    // Bar
    public Color defaultColor;
    Color spriteColor;
    bool containsHex = false, containsSquare = false, containsTriangle = false;

    void Awake()
    {
        spriteColor = Random.ColorHSV(0.2f, 0.8f, 1f, 1f, 1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().material.color = spriteColor;
    }

	void Update () {
        if (transform.parent != null)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        } else
        {
            float gravity = Player.currentScale / 10;
            GetComponent<Rigidbody2D>().gravityScale = gravity;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (this.gameObject.tag == "hexColorPiece")
        {
            for (int i = 0; i < ShapeBar.shapeColorPieces.Count; i++)
            {
                if (ShapeBar.shapeColorPieces[i].gameObject.tag == "barHex")
                {
                    if (ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color == defaultColor)
                    {
                        ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color = spriteColor;
                        containsHex = true;
                        LevelManager.numFilled++;
                        break;
                    }
                }
            }

            if (!containsHex)
                ResetBarShapes();
        }

        if(this.gameObject.tag == "squareColorPiece")
        {
            for (int i = 0; i < ShapeBar.shapeColorPieces.Count; i++)
            {
                if (ShapeBar.shapeColorPieces[i].gameObject.tag == "barSquare")
                {
                    if (ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color == defaultColor)
                    {
                        ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color = spriteColor;
                        containsSquare = true;
                        LevelManager.numFilled++;
                        break;
                    }
                }
            }

            if(!containsSquare)
                ResetBarShapes();
        }

        if(this.gameObject.tag == "triangleColorPiece")
        {
            for (int i = 0; i < ShapeBar.shapeColorPieces.Count; i++)
            {
                if (ShapeBar.shapeColorPieces[i].gameObject.tag == "barTriangle")
                {
                    if (ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color == defaultColor)
                    {
                        ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color = spriteColor;
                        LevelManager.numFilled++;
                        containsTriangle = true;
                        break;
                    }
                }
            }

            if (!containsTriangle)
                ResetBarShapes();
        }
        Destroy(this.gameObject, 0.2f);
    }

    void ResetBarShapes()
    {
        foreach(GameObject shape in ShapeBar.shapeColorPieces)
        {
            shape.GetComponent<SpriteRenderer>().material.color = defaultColor;
            containsHex = false;
            containsSquare = false;
            containsTriangle = false;
            LevelManager.numFilled = 0;
        }
    }
}
