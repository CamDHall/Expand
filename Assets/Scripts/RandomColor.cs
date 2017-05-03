using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour {

    float timeLeft;
    Color targetColor;

    void Start()
    {
        targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
    }

	void Update () {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            GetComponent<Text>().color = targetColor;

            // start a new transition
            targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            timeLeft = 2f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }
}
