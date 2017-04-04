using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int level = 10;
    public static Color levelColor;

    // Track and pick shape
    public static string lastShape;
    int shapeChoice;

    // Level Grid
    int width = 5;
    int height = 5;

    // Image and fill
    public static float hexUIFill, squareUIFill, triangleUIFill;
    public static float levelFill;
    public Image hexagonUI, squareUI, triangleUI;

    // Level images
    public Image _squareBackground, _squareFill, _hexBackground, _hexFill, _triangleBackground, _triangleFill;
    public static Vector2 hexagonUIPos, squareUIPos, triangleUIPos;

    void Start() {
        hexagonUIPos = hexagonUI.transform.position;
        squareUIPos = squareUI.transform.position;
        triangleUIPos = triangleUI.transform.position;

        hexUIFill = 0;
        squareUIFill = 0;
        triangleUIFill = 0;
    }

    void Update() {
        hexagonUI.GetComponent<Image>().fillAmount = hexUIFill;
        squareUI.GetComponent<Image>().fillAmount = squareUIFill;
        triangleUI.GetComponent<Image>().fillAmount = triangleUIFill;
    }
}
