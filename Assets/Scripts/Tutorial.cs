using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Text movement, expansion, shrink, objective, caution;
    public GameObject icon;
    string phase;
    float Timer;
    public GameObject staticObstacle, obstacle, goal, bar;

	void Start () {
        phase = "Movement";
        expansion.GetComponent<Text>().enabled = false;
        shrink.GetComponent<Text>().enabled = false;
        objective.GetComponent<Text>().enabled = false;
        caution.GetComponent<Text>().enabled = false;
	}
	
	void Update () {

        if(Input.GetMouseButtonDown(0) && phase == "Movement")
        {
            movement.GetComponent<Text>().enabled = false;
            Timer = Time.timeSinceLevelLoad + 1f;
            phase = "Expansion";
        }

        if(phase == "Expansion" && Time.timeSinceLevelLoad > Timer)
        {
            phase = "Shrinking";
            expansion.GetComponent<Text>().enabled = true;
            Timer = Time.timeSinceLevelLoad + 5f;
        }

        if(phase == "Shrinking" && Time.timeSinceLevelLoad > Timer)
        {
            expansion.GetComponent<Text>().enabled = false;
            icon.GetComponent<SpriteRenderer>().enabled = false;
            shrink.GetComponent<Text>().enabled = true;
            Timer = Time.timeSinceLevelLoad + 3f;
            phase = "Obstacles";
        }

        if(phase == "Obstacles" && Time.timeSinceLevelLoad > Timer)
        {
            shrink.GetComponent<Text>().enabled = false;
            objective.GetComponent<Text>().enabled = true;
            Instantiate(staticObstacle);
            Instantiate(bar);

            Timer = Time.timeSinceLevelLoad + 3f;
            phase = "Caution";
        }

        if(phase == "Caution" && Time.timeSinceLevelLoad > Timer)
        {
            objective.GetComponent<Text>().enabled = false;
            caution.GetComponent<Text>().enabled = true;
            phase = "Demo";
            Timer = Time.timeSinceLevelLoad + 5f;
        }

        if(phase == "Demo" && Time.timeSinceLevelLoad > Timer)
        {
            Destroy(staticObstacle);
            caution.GetComponent<Text>().enabled = false;
            Obstacles();
            phase = "Powerups";
            Timer = Time.timeSinceLevelLoad + 5f;
        }

        // Finish Later
        if(phase == "Powerups" && Time.timeSinceLevelLoad > Timer)
        {
            SceneManager.LoadScene("MainScreen");
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved && phase == "Movement")
            {
                movement.GetComponent<Text>().enabled = false;
                Timer = Time.timeSinceLevelLoad + 1f;
                phase = "Expansion";
            }
        }
    }

    void Obstacles()
    {
        Instantiate(obstacle);
    }
}
