using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Goal")
        {
            Destroy(coll.gameObject, .25f);
        }
    }
}
