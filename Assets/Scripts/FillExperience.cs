using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillExperience : MonoBehaviour {

    float fill;
    public Text levelUp, currentLevel;

    void Start()
    {
        currentLevel.text = "Level: " + LevelManager.currentLevel.ToString();
    }

    void Update()
    {
        fill = LevelManager.currentExperience / LevelManager.requiredExperience;
        GetComponent<Image>().fillAmount = Mathf.LerpUnclamped(GetComponent<Image>().fillAmount, fill, Time.deltaTime);
        if(GetComponent<Image>().fillAmount >= 1)
        {
            LevelManager.currentLevel++;
            currentLevel.text = "Level: " + LevelManager.currentLevel.ToString();
            LevelManager.currentExperience -= LevelManager.requiredExperience;
            GetComponent<Image>().fillAmount = Mathf.LerpUnclamped(GetComponent<Image>().fillAmount, fill, Time.deltaTime);
            var level = Instantiate(levelUp);
            level.transform.SetParent(transform, false);
        }
    }
}
