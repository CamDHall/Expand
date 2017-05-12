using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Text movement, expansion, shrink, objective, caution, powerUpActive;
    public GameObject icon, spawner;
    string phase, resume_phase;
    float Timer;

    // Death
    public Animator button;

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

        if(Player.death)
        {
            button.SetBool("Died", true);
            phase = "Idle";
        }

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
            spawner.GetComponent<Spawner>().enabled = true;
        }

        if(phase == "Obstacles" && Time.timeSinceLevelLoad > Timer)
        {
            shrink.GetComponent<Text>().enabled = false;
            objective.GetComponent<Text>().enabled = true;

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

            phase = "Powerups";
            Timer = Time.timeSinceLevelLoad + 3f;
        }

        // Finish Later
        if(phase == "Powerups" && Time.timeSinceLevelLoad > Timer)
        {
            powerUpActive.GetComponent<Text>().enabled = true;
            Timer = Time.timeSinceLevelLoad + 4.5f;

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

    public void ContinueButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
