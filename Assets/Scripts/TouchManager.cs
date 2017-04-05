using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{

    // Shape Information
    public static Vector3 circleShapePos, squareShapePos, triangleShapePos;
    public static int _hexes, _squares, _triangles; // Number of hexes

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

    /*
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
    } */
}
