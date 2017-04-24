using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour {

    // Goals
    public GameObject sphere;
    public static Vector3 goalPos;
    Color goalColor;

    // Scale
    float lowScale = 0.8f, highScale = 1.0f, lowScaleMutliplyer = 0, highScaleMultiplyer = 0, counter = 0;

    // Gravity
    float gravity, goalGravity = 1.01f;

    public void Goal()
    {
        // Position
        goalPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(3.75f, 7f), 0);

        counter++;
        if (counter <= 10)
        {
            lowScaleMutliplyer = counter * 0.01f;
            highScaleMultiplyer = counter * 0.001f;
        }
        else if (counter <= 20)
        {
            lowScaleMutliplyer = counter * 0.001f;
            highScaleMultiplyer = counter * 0.0001f;
        }
        else if (counter <= 50)
        {
            lowScaleMutliplyer = counter * 0.0001f;
            highScaleMultiplyer = counter * 0.00001f;
        }

        lowScale += lowScaleMutliplyer;
        highScale += highScaleMultiplyer;

        // Instantiate
        GameObject circle = Instantiate(sphere, transform);
        var scale = Random.Range(lowScale, highScale);
        sphere.transform.localScale = new Vector3(scale, scale, 0);
        sphere.transform.position = goalPos;

        // Color
        goalColor = new Color(Random.value, Random.value, Random.value, 1f);
        circle.GetComponent<SpriteRenderer>().material.color = goalColor;

        // Gravity
        sphere.GetComponent<Rigidbody2D>().gravityScale = goalGravity / (1 + scale);

        Debug.Log(scale);
    }
}
