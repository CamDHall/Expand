using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text level;

    void Start()
    {
        level.text = "Level: " + LevelManager.playerLevel;
    }

	public void NextLevel()
    {
        SceneManager.LoadScene("main");
    }
}
