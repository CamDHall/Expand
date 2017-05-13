using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Animator nextButton;

    Dictionary<string, string> text_options;
    public GameObject player, exampleBar, square, squareWall, powerup, hexLast;
    string currentPhase;
    public Text text, start;

    void Start()
    {
        text = text.GetComponent<Text>();
        currentPhase = "Movement";
        text_options = new Dictionary<string, string>()
        {
            {"Movement", "TOUCH TO MOVE HORIZTONALLY" },
            {"Growth", "YOU'LL SHRINK WHEN YOU'RE NOT TOUCHING" },
            {"Death", "IF YOU SHRINK TOO MUCH, YOU'll DIE." },
            {"Objectives", "COLLECT THE FALLING SHAPES TO FILL THE BAR AND LEVEL UP!" },
            {"Caution", "HITTING RED WALLS WILL SHRINK YOU!" },
            {"Collect", "COLLECT A POWERUP TO STORE IT" },
            { "Powerup", "TAP A STORED POWERUP TO ACTIVATE IT" },
            {"Last", "ONLY COLLECT SHAPES YOU NEED!" }
        };
    }

    void Update()
    {
        text.text = text_options[currentPhase];
        if (currentPhase == "Death" || currentPhase == "Caution" || currentPhase == "Last")
            text.color = Color.red;
        else
            text.color = Color.white;
    }

    public void NextButton()
    {
        switch (currentPhase)
        {
            case "Movement":
                currentPhase = "Growth";
                break;
            case "Growth":
                player.transform.localScale = Vector3.Lerp(player.transform.localScale, new Vector3(0.3f, 0.3f, 0.3f), Time.deltaTime);
                currentPhase = "Death";
                break;
            case "Death":
                player.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                exampleBar.SetActive(true);
                square.SetActive(true);

                currentPhase = "Objectives";
                break;
            case "Objectives":
                squareWall.SetActive(true);
                currentPhase = "Caution";
                break;
            case "Caution":
                currentPhase = "Collect";
                powerup.SetActive(true);
                break;
            case "Collect":
                currentPhase = "Powerup";
                break;
            case "Powerup":
                currentPhase = "Last";
                start.text = "START";
                hexLast.SetActive(true);
                break;
            case "Last":
                SceneManager.LoadScene("MainScreen");
                break;
        }
    }

}
