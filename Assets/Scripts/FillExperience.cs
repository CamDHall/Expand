using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillExperience : MonoBehaviour {

    float fill;

    void Update()
    {
        fill = LevelManager.currentExperience / LevelManager.requiredExperience;
        GetComponent<Image>().fillAmount = Mathf.LerpUnclamped(GetComponent<Image>().fillAmount, fill, Time.deltaTime);
        if(GetComponent<Image>().fillAmount >= 1)
        {
            LevelManager.currentExperience -= LevelManager.requiredExperience;
            GetComponent<Image>().fillAmount = Mathf.LerpUnclamped(GetComponent<Image>().fillAmount, fill, Time.deltaTime);
        }
    }
}
