using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{

    // Shape Information
    public static Vector3 hexagonShapePos, squareShapePos, triangleShapePos;
    public static int _hexes, _squares, _triangles; // Number of hexes

    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    string currentUIFlash;

    void Start()
    {
        hexagonShapePos = new Vector3(6, 0, 0);
        squareShapePos = new Vector3(6, 0, 0);
        triangleShapePos = new Vector3(6, 0, 0);
    }

    void Update()
    {
        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            //We transform the touch position into word space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
            }
        }
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
