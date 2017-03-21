using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour {

    public void Intro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Play()
    {
        SceneManager.LoadScene("main");
    }
}
