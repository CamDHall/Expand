using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour {

    // Goals
    public GameObject sphere;
    public static Vector3 goalPos;
    Color goalColor;

    // Gravity
    float gravity, goalGravity = 1.01f;

    public void Goal()
    {
        // Position
        goalPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(3.75f, 7f), 0);

        // Instantiate
        GameObject circle = Instantiate(sphere, transform);
        var scale = Random.Range(0.75f, 3f);
        sphere.transform.localScale = new Vector3(scale, scale, 0);
        sphere.transform.position = goalPos;

        // Color
        goalColor = new Color(Random.value, Random.value, Random.value, 1f);
        circle.GetComponent<SpriteRenderer>().material.color = goalColor;

        // Gravity
        sphere.GetComponent<Rigidbody2D>().gravityScale = goalGravity / (1 + scale);
    }
}
