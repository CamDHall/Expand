using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public static float Score; 
    float timeMultiplier;
    public Text _Score;
    float displayScore;

	void Start () {
        Score = 0;
	}
	
	void Update () {

        Score += Time.time / 150f;
        displayScore = Mathf.Floor(Score);
        _Score.text = displayScore.ToString();
    }
}
