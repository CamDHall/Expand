﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log("Left TRIGGER");
        if (coll.gameObject.tag == "Goal" || coll.gameObject.tag == "Triangle"
            || coll.gameObject.tag == "Circle" || coll.gameObject.tag == "Square"
            || coll.gameObject.tag == "circlePiece" || coll.gameObject.tag == "squarePiece"
            || coll.gameObject.tag == "trianglePiece")
        {
            Destroy(coll.gameObject, 0.25f);
        } 
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Destroy(coll.gameObject, 0.25f);
    }
}
