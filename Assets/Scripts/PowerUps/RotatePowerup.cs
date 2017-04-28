using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerup : MonoBehaviour {

    const float speed = 1f;
    float degreeRotate;

    void Start()
    {
        degreeRotate = Random.Range(12f, 24f);
    }

    void Update()
    {
        transform.Rotate(degreeRotate * Time.deltaTime, degreeRotate * Time.deltaTime, degreeRotate * Time.deltaTime);
    }
}
