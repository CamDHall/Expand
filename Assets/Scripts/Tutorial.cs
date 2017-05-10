using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Text movement, expansion, shrink, objective, caution, powerUpActive;
    public GameObject icon;
    string phase;
    float Timer;
    public GameObject staticObstacle, obstacle, goal, bar, grow;

    GameObject obstacleVar;

	void Start () {
        phase = "Movement";
        expansion.GetComponent<Text>().enabled = false;
        shrink.GetComponent<Text>().enabled = false;
        objective.GetComponent<Text>().enabled = false;
        caution.GetComponent<Text>().enabled = false;
        powerUpActive.GetComponent<Text>().enabled = false;
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
            obstacleVar = Instantiate(staticObstacle);
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
            Destroy(obstacleVar);
            caution.GetComponent<Text>().enabled = false;
            Obstacles();
            phase = "Powerups";
            Timer = Time.timeSinceLevelLoad + 3f;
        }

        // Finish Later
        if(phase == "Powerups" && Time.timeSinceLevelLoad > Timer)
        {
            var growPower = Instantiate(grow);
            growPower.GetComponent<Rigidbody2D>().gravityScale = 0.1f;

            powerUpActive.GetComponent<Text>().enabled = true;
            Timer = Time.timeSinceLevelLoad + 3f;

            phase = "Transition";
        }

        if(phase == "Transition" && Time.timeSinceLevelLoad > Timer)
        {
            icon.GetComponent<SpriteRenderer>().enabled = true;
            icon.transform.position = new Vector3(0.5f, 3, 0);

            phase = "PowerUpIdle";
        }

        if(phase == "PowerUpIdle" && PowerUpManager.boostedTouched)
        {
            powerUpActive.GetComponent<Text>().enabled = false;
            icon.GetComponent<SpriteRenderer>().enabled = false;


            phase = "Finished";
            Timer = Time.timeSinceLevelLoad + 5f;
        }

        if(phase == "Finished" && Time.timeSinceLevelLoad > Timer)
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
