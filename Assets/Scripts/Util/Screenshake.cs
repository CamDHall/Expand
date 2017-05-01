using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Put on camera
[RequireComponent(typeof(Camera))]
public class Screenshake : MonoBehaviour
{

    public float shakeStrength;
    Vector3 startPos;
    public static bool shaking;

    void Start()
    {
        startPos = transform.position;
        shaking = false;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, startPos + Random.insideUnitSphere * shakeStrength, Time.deltaTime * 5f);

        if (shaking)
        {
            shakeStrength = 3f;
            shaking = false;
        }

        shakeStrength = Mathf.Lerp(shakeStrength, 0f, Time.deltaTime * 4f);
    }
}
