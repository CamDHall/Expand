using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    public static int level = 0;
    public static Color levelColor;

    // Track and pick shape
    public static string lastShape;
    int shapeChoice;

    // Image and fill
    public static float hexUIFill, squareUIFill, triangleUIFill;
    public static float levelFill;
    public Image hexagonUI, squareUI, triangleUI;

    // Level images
    public Image _squareBackground, _squareFill, _hexBackground, _hexFill, _triangleBackground, _triangleFill;
    public static Vector2 hexagonUIPos, squareUIPos, triangleUIPos;

	void Start () {
        hexagonUIPos = hexagonUI.transform.position;
        squareUIPos = squareUI.transform.position;
        triangleUIPos = triangleUI.transform.position;

        hexUIFill = 0;
        squareUIFill = 0;
        triangleUIFill = 0;

        // pick color
        levelColor = Random.ColorHSV();

        // Create goal shapes
        shapeChoice = Random.Range(1, 3);

        if(shapeChoice == 1)
        {
            _hexBackground.gameObject.SetActive(true);
            _hexFill.color = levelColor;
        } else if(shapeChoice == 2)
        {
            _squareBackground.gameObject.SetActive(true);
            _squareFill.color = levelColor;
        } else
        {
            _triangleBackground.gameObject.SetActive(true);
            _triangleFill.color = levelColor;
        }
	}
	
	void Update () {
        hexagonUI.GetComponent<Image>().fillAmount = hexUIFill;
        squareUI.GetComponent<Image>().fillAmount = squareUIFill;
        triangleUI.GetComponent<Image>().fillAmount = triangleUIFill;

        _hexFill.GetComponent<Image>().fillAmount = levelFill;
        _squareFill.GetComponent<Image>().fillAmount = levelFill;
        _triangleFill.GetComponent<Image>().fillAmount = levelFill;

        if(levelFill >= 1)
        {
            SceneManager.LoadScene("WinScreen");
            level++;
        }
    }
}
