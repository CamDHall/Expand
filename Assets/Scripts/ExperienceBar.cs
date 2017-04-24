using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour {

    float distCovered;
    float elapsedTime;
    public Image fill;
    public Button returnToMenu, playAgain;
    public Text Lives;

    void Awake()
    {
        fill.fillAmount = LevelManager.currentExperience/LevelManager.requiredExperience;
        Lives.text = LevelManager.lives.ToString();
    }
	
	void Update () {
        if (transform.position.x < 0)
        {
            distCovered = Vector3.Distance(transform.position, Vector3.zero);
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, (elapsedTime) * 0.1f);
            elapsedTime += Time.deltaTime;
        } else
        {
            fill.fillAmount = LevelManager.currentExperience / LevelManager.requiredExperience;
            if(LevelManager.currentExperience >= LevelManager.requiredExperience)
            {
                LevelManager.currentExperience -= LevelManager.requiredExperience;
            }
        }
	}
}
