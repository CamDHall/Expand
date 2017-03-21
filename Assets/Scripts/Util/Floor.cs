using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Goal")
        {
            Destroy(coll.gameObject, 0.25f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject, 0.25f);
    }
}
