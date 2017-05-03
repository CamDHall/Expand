﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{

    // Shape Information
    public static Vector3 hexagonShapePos, squareShapePos, triangleShapePos;
    public static int _hexes, _squares, _triangles; // Number of hexes

    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    string currentUIFlash;

    void Start()
    {
        hexagonShapePos = new Vector3(6, 0, 0);
        squareShapePos = new Vector3(6, 0, 0);
        triangleShapePos = new Vector3(6, 0, 0);
    }

    void Update()
    {
        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

            if (hit.collider != null)
            {
                GameObject touchedObject = hit.transform.gameObject;

                if (hit.transform.tag == "CanBoost")
                {
                    PowerUpManager.boost = true;
                    Destroy(touchedObject);
                    PowerUpManager.currentPowerups.Remove(touchedObject);
                    PowerUpManager.boostPowerups -= 1;
                }
                else if (hit.transform.tag == "CanDamage")
                {
                    PowerUpManager.damage = true;
                    Destroy(touchedObject);
                    PowerUpManager.currentPowerups.Remove(touchedObject);
                    PowerUpManager.damagePowerups -= 1;
                }
                else if (hit.transform.tag == "CanFreeze")
                {
                    PowerUpManager.freeze = true;
                    PowerUpManager.freezeTimer = Time.timeSinceLevelLoad + 5f;
                    Destroy(touchedObject);
                    PowerUpManager.currentPowerups.Remove(touchedObject);
                    PowerUpManager.freezePowerups -= 1;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            //We transform the touch position into word space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                if (touchedObject.tag == "CanBoost")
                {
                    PowerUpManager.boost = true;
                    Destroy(touchedObject);
                    PowerUpManager.currentPowerups.Remove(touchedObject);
                    PowerUpManager.boostPowerups -= 1;
                }
                else if (touchedObject.tag == "CanFreeze")
                {
                    PowerUpManager.freeze = true;
                    PowerUpManager.freezeTimer = Time.timeSinceLevelLoad + 5f;
                    Destroy(touchedObject);
                    PowerUpManager.currentPowerups.Remove(touchedObject);
                    PowerUpManager.freezePowerups -= 1;
                }
                else if (touchedObject.tag == "CanDamage")
                {
                    PowerUpManager.damage = true;
                    Destroy(touchedObject);
                    PowerUpManager.currentPowerups.Remove(touchedObject);
                    PowerUpManager.damagePowerups -= 1;
                }
            }
        }
    }
}
