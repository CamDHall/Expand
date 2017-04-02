﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    float addMass;
    static public float currentScale;
    public static Vector3 Pos;

    // Scaling
    float shrink;
    Vector3 newScale;
    float speed = 0.1f;
    bool notTouching = true;

    public static bool madeGoal = false;

    // Camera Shake
    public GameObject CameraShake;

    void Start() {
        newScale = new Vector3(0.9f, 0.9f, 0);
    }

    void Update()
    {
        Debug.Log(TouchManager._hexes);
        // TEST MOUSE
        if (Input.GetMouseButton(0))
        {
            Vector3 Pos = Input.mousePosition;
            Pos = Camera.main.ScreenToWorldPoint(Pos);
            transform.position = new Vector3(Pos.x, transform.position.y, transform.position.z);

            notTouching = false;
            addMass = Time.deltaTime / 10f;
            transform.localScale = new Vector3(transform.localScale.x + addMass, transform.localScale.y + addMass, 0);

        }

        if(Input.GetMouseButtonUp(0))
        {
            notTouching = true;
        }
        // TEST MOUSE

        if (transform.localScale.x < 0.5f)
        {
            SceneManager.LoadScene("End");
        }
        currentScale = transform.localScale.x;

        foreach (Touch touch in Input.touches)
        {
            Pos = Camera.main.ScreenToWorldPoint(touch.position);

            transform.position = new Vector3(Pos.x, transform.position.y, 0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                addMass = Input.GetTouch(0).deltaTime / 10f;
                notTouching = false;
                transform.localScale = new Vector3(transform.localScale.x + addMass, transform.localScale.y + addMass, 0);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                notTouching = true;
            }
        }

        if (notTouching)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Goal")
        {
            Scoring.Score += (coll.transform.localScale.x * 50f);

            var newScale = new Vector3(transform.localScale.x + coll.gameObject.transform.localScale.x, transform.localScale.x + coll.gameObject.transform.localScale.y, 0);
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, 1f * Time.deltaTime);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "hexagonPiece")
        {
            Destroy(coll.gameObject);
            LevelManager.hexUIFill += 1f;
        }

        if (coll.gameObject.tag == "squarePiece")
        {
            Destroy(coll.gameObject);
            LevelManager.squareUIFill += 1f;
        }

        if (coll.gameObject.tag == "trianglePiece")
        {
            Destroy(coll.gameObject);
            LevelManager.triangleUIFill += 1f;
        }

        if (coll.gameObject.tag == "colorPiece")
        {
            LevelManager.levelFill += (1 - (0.01f * (LevelManager.level)));
            Destroy(coll.gameObject, 0.2f);
        }

        if (coll.gameObject.tag == "Hexagon" || coll.gameObject.tag == "Square" || coll.gameObject.tag == "Triangle")
        {
            transform.localScale -= new Vector3(transform.localScale.x * 0.6f, transform.localScale.y * 0.6f, 0);
            coll.gameObject.transform.DetachChildren();
            Destroy(coll.gameObject);

            if (coll.gameObject.tag == "Hexagon")
                TouchManager._hexes--;
            if (coll.gameObject.tag == "Square")
                TouchManager._squares--;
            if (coll.gameObject.tag == "Triangle")
                TouchManager._triangles--;
        } 
    }
}
