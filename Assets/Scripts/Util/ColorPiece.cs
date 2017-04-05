using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour {

    public Color defaultColor;

	void Start () {
        
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
        bool containsHex = false;

        if (this.gameObject.tag == "hexColorPiece")
        {
            for(int i = 0; i < ShapeBar.shapeColorPieces.Count; i++)
            {
                if (ShapeBar.shapeColorPieces[i].gameObject.tag == "barHex")
                {
                    if (ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color == defaultColor)
                    {
                        ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color = Color.white;
                        break;
                    }
                }
            }

            if (!containsHex)
                ResetBarShapes();
        }

        if(this.gameObject.tag == "squareColorPiece")
        {
            bool containsSquare = false;

            for (int i = 0; i < ShapeBar.shapeColorPieces.Count; i++)
            {
                if (ShapeBar.shapeColorPieces[i].gameObject.tag == "barSquare")
                {
                    if (ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color == defaultColor)
                    {
                        ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color = Color.white;
                        containsSquare = true;
                        break;
                    }
                }
            }

            if(!containsSquare)
                ResetBarShapes();
        }

        if(this.gameObject.tag == "triangleColorPiece")
        {
            bool containsTriangle = false;

            for (int i = 0; i < ShapeBar.shapeColorPieces.Count; i++)
            {
                if (ShapeBar.shapeColorPieces[i].gameObject.tag == "barTriangle")
                {
                    if (ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color == defaultColor)
                    {
                        ShapeBar.shapeColorPieces[i].GetComponent<SpriteRenderer>().material.color = Color.white;
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
        }
    }
}
