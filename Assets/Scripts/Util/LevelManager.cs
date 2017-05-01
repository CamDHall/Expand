using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static Color levelColor;
    public static int numFilled;
    int numOfShapes = 0;
    int deathCalled = 0;

    public GameObject experienceBar, mainMenuButton, playAgainButton;

    // Level and Scaling
    public static float currentExperience = 0, requiredExperience = 0;
    public static float playerScale;
    public static int lives = 3;
    public static int currentLevel = 0;

    // Track and pick shape
    public static string lastShape;

    Spawner spawner;
    bool savedOnDeath = false;
    void Awake()
    {
        if (currentLevel == 0)
        {
            playerScale = 0.8f;
            requiredExperience = 30;
        }
        else if (currentLevel <= 10)
        {
            playerScale = (currentLevel / 15) + 0.8f;
            requiredExperience = (currentLevel * 10) + 100;
        }
        else if (currentLevel <= 20)
        {
            playerScale = (currentLevel / 10) + 0.8f;
            requiredExperience = (currentLevel * 30) + 100;
        }
     
        else if (currentLevel <= 30)
        {
            playerScale = (currentLevel / 5) + 0.8f;
            requiredExperience = (currentLevel * 50) + 100;
        }

        else
        {
            playerScale = (currentLevel / 8) + 0.8f;
            requiredExperience = (currentLevel * 100) + 100;
        }

        numFilled = 0;
    }

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }

    void Update()
    {
        if (Player.death && deathCalled == 0)
        {
            Experience();
            deathCalled++;

            if(!savedOnDeath)
            {
                GameController.control.Save();
                savedOnDeath = true;
            }
        }
    }

    void Experience()
    {
        experienceBar.SetActive(true);
        playAgainButton.SetActive(true);
        mainMenuButton.SetActive(true);
        for (int i = 0; i < spawner.filledShapeBars.Count; i++)
        {
            numOfShapes += spawner.filledShapeBars[i].transform.childCount;
        }

        currentExperience += numOfShapes;
    }

    void OnApplicationQuit()
    {
        GameController.control.Save();
    }
}
