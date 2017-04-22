using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

	public void PlayAgain()
    {
        SceneManager.LoadScene("main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
