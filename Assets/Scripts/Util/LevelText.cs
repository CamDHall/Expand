using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	void Start () {
        GetComponent<Text>().text = "Level: " + LevelManager.currentLevel.ToString();	
	}
}
