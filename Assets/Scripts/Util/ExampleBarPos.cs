using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBarPos : MonoBehaviour {

    // Sizing
    Vector3 screenDimensions;
    float screenWidth;

    void Awake()
    {
        screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        screenWidth = screenDimensions.x;
    }

    void Start () {
        transform.position = new Vector2(-0.75f - screenWidth / 2, -4.5f + 0.75f);
    }

	void Update () {
		
	}
}
