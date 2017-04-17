using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour {

    float distCovered;
    float elapsedTime;
    public Image fill;

    void Awake()
    {
        fill.fillAmount = LevelManager.currentExperience/LevelManager.requiredExperience;
    }
	
	void Update () {

        Debug.Log(elapsedTime * 0.1f);
        if (transform.position.x < 0)
        {
            distCovered = Vector3.Distance(transform.position, Vector3.zero);
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, (elapsedTime) * 0.1f);
            elapsedTime += Time.deltaTime;
        } else
        {
            fill.fillAmount = LevelManager.currentExperience / LevelManager.requiredExperience;
        }
	}
}
