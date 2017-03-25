using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static float circleFillLevel, squareFillLevel, triangleFillLevel;
    public Image circleUI, squareUI, triangleUI;

	void Start () {
		
	}
	
	void Update () {
        circleUI.GetComponent<Image>().fillAmount = circleFillLevel;
        squareUI.GetComponent<Image>().fillAmount = squareFillLevel;
        triangleUI.GetComponent<Image>().fillAmount = triangleFillLevel;
	}
}
