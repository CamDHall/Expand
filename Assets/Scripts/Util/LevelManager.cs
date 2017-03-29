using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


    public static int level = 0;

    // Track and pick shape
    public static string lastShape;
    int shapeChoice;

    // Image and fill
	public static float hexagonFillLevel, squareFillLevel, triangleFillLevel, levelFill;
    public Image hexagonUI, squareUI, triangleUI;

    // Level images
    public Image _squareBackground, _squareFill, _hexBackground, _hexFill, _triangleBackground, _triangleFill;
    public static Vector2 hexagonUIPos, squareUIPos, triangleUIPos;

	void Start () {
        hexagonUIPos = hexagonUI.transform.position;
        squareUIPos = squareUI.transform.position;
        triangleUIPos = triangleUI.transform.position;

        hexagonFillLevel = 0;
        squareFillLevel = 0;
        triangleFillLevel = 0;

        level = 0;

        // Create goal shapes
        shapeChoice = Random.Range(1, 3);

        if(shapeChoice == 1)
        {
            _hexBackground.gameObject.SetActive(true);
        } else if(shapeChoice == 2)
        {
            _squareBackground.gameObject.SetActive(true);
        } else
        {
            _triangleBackground.gameObject.SetActive(true);
        }
	}
	
	void Update () {
        hexagonUI.GetComponent<Image>().fillAmount = hexagonFillLevel;
        squareUI.GetComponent<Image>().fillAmount = squareFillLevel;
        triangleUI.GetComponent<Image>().fillAmount = triangleFillLevel;

        _hexFill.GetComponent<Image>().fillAmount = levelFill;
        _squareFill.GetComponent<Image>().fillAmount = levelFill;
        _triangleFill.GetComponent<Image>().fillAmount = levelFill;
    }
}
