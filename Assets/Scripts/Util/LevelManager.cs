using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static float circleFillLevel, squareFillLevel, triangleFillLevel;
    public Image circleUI, squareUI, triangleUI;
    public static Vector2 circleUIPos, squareUIPos, triangleUIPos;

	void Start () {
        circleUIPos = circleUI.transform.position;
        squareUIPos = squareUI.transform.position;
        triangleUIPos = triangleUI.transform.position;
	}
	
	void Update () {
        circleUI.GetComponent<Image>().fillAmount = circleFillLevel;
        squareUI.GetComponent<Image>().fillAmount = squareFillLevel;
        triangleUI.GetComponent<Image>().fillAmount = triangleFillLevel;
	}
}
