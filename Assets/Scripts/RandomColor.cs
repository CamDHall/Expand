using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour {

    Color changeColor;
    float Timer;

    void Start()
    {
        changeColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        GetComponent<Text>().color = changeColor;
        Timer = 0;
    }

	void Update () {
        
        if (Time.timeSinceLevelLoad > Timer)
        {
            GetComponent<Text>().color = Color.LerpUnclamped(GetComponent<Text>().color, changeColor, Time.deltaTime * 2.0f);
            changeColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            Timer = Time.timeSinceLevelLoad + (10f * Time.deltaTime); 
        }
	}
}
