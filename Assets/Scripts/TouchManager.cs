using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Image hexagonFill, squareFill, triangleFill; // Levels
    public GameObject hexagonPiece, squarePiece, trianglePiece;

    // Shape Information
    public static Vector3 circleShapePos, squareShapePos, triangleShapePos;
    public static int _hexes, _squares, _triangles; // Number of hexes

    public Image hexBackgroundUI, squareBackgroundUI, triangleBackgroundUI;
    public Image hexFillUI, squareFillUI, triangleFillUI;

    string currentUIFlash;

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
        currentUIFlash = "HEX";
        if (LevelManager.hexUIFill >= 1)
        {
            if(_hexes > 0)
            {
                GameObject deleteCircle = GameObject.FindGameObjectWithTag("Circle");
                deleteCircle.transform.DetachChildren();
                Destroy(deleteCircle);

                _hexes--; // Lower number of hex shapes in the game
            } else
            {
                StartCoroutine("FillFlash");
            }
        } else
        {
            StartCoroutine("Flash");
        }
    }

    public void SquareUI()
    {
        currentUIFlash = "SQUARE";

        if (LevelManager.squareUIFill >= 1)
        {
            if (_squares > 0)
            {
                GameObject deleteSquare = GameObject.FindGameObjectWithTag("Square");
                deleteSquare.transform.DetachChildren();
                Destroy(deleteSquare);

                _squares--; // Lower number of squares shapes in the game
            } else
            {
                StartCoroutine("FillFlash");
            }
        }
        else
        {
            StartCoroutine("Flash");
        }
    }

    public void TriangleUI()
    {
        currentUIFlash = "TRIANGLE";

        if (LevelManager.triangleUIFill >= 1)
        {
            if(_triangles > 0)
            {
                GameObject deleteTriangle = GameObject.FindGameObjectWithTag("Triangle");
                deleteTriangle.transform.DetachChildren();
                Destroy(deleteTriangle);

                _triangles--; // Lower number of triangles shapes in the game
            }   else
            {
                StartCoroutine("FillFlash");
            }
        }
        else
        {
            StartCoroutine("Flash");
        }
    }

    IEnumerator Flash()
    {
        if(currentUIFlash == "HEX")
        {
            hexBackgroundUI.GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(1.5f);
            hexBackgroundUI.GetComponent<Image>().color = Color.white;
        }

        if(currentUIFlash == "SQUARE")
        {
            squareBackgroundUI.GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(1.5f);
            squareBackgroundUI.GetComponent<Image>().color = Color.white;
        }

        if (currentUIFlash == "TRIANGLE")
        {
            Debug.Log("Triangle");
            triangleBackgroundUI.GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(1.5f);
            triangleBackgroundUI.GetComponent<Image>().color = Color.white;
        }
    }

    IEnumerator FillFlash()
    {
        if (currentUIFlash == "HEX")
        {
            hexFillUI.GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(1.5f);
            hexFillUI.GetComponent<Image>().color = Color.red;
        }

        if (currentUIFlash == "SQUARE")
        {
            squareFillUI.GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(1.5f);
            squareFillUI.GetComponent<Image>().color = Color.red;
        }

        if (currentUIFlash == "TRIANGLE")
        {
            Debug.Log("Triangle");
            triangleFillUI.GetComponent<Image>().color = Color.grey;
            yield return new WaitForSeconds(1.5f);
            triangleFillUI.GetComponent<Image>().color = Color.red;
        }
    }
}
