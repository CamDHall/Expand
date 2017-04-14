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

    public GameObject experienceBar; // Initiate at beginging of round to fill with current experience

    // Level and Scaling
    public static float playerLevel = 1, currentExperience = 0, requiredExperience = 0;
    public static float playerScale;


    // Track and pick shape
    public static string lastShape;

    Spawner spawner;

    void Awake()
    {
        if (playerLevel == 0)
        {
            playerScale = 0.8f;
            requiredExperience = 100;
        }
        else if (playerLevel <= 10)
        {
            playerScale = (playerLevel / 15) + 0.8f;
            requiredExperience = (playerLevel * 10) + 100;
        }
        else if (playerLevel <= 20)
        {
            playerScale = (playerLevel / 10) + 0.8f;
            requiredExperience = (playerLevel * 30) + 100;
        }
     
        else if (playerLevel <= 30)
        {
            playerScale = (playerLevel / 5) + 0.8f;
            requiredExperience = (playerLevel * 50) + 100;
        }

        else
        {
            playerScale = (playerLevel / 4) + 0.8f;
            requiredExperience = (playerLevel * 100) + 100;
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
        }
    }

    void Experience()
    {
        experienceBar.SetActive(true);
        for (int i = 0; i < spawner.filledShapeBars.Count; i++)
        {
            numOfShapes += spawner.filledShapeBars[i].transform.childCount;
        }

        currentExperience += numOfShapes;
    }
}
