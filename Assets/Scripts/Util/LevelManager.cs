using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static Color levelColor;
    public static int numFilled;

    // Track and pick shape
    public static string lastShape;
    int shapeChoice;

    void Start()
    {
        numFilled = 0;
    }

    void Update() {

    }
}
