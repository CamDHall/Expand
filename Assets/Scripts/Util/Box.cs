using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Goal" || coll.gameObject.tag == "Triangle"
            || coll.gameObject.tag == "Circle" || coll.gameObject.tag == "Square"
            || coll.gameObject.tag == "circlePiece" || coll.gameObject.tag == "squarePiece"
            || coll.gameObject.tag == "trianglePiece")
        {
            Destroy(coll.gameObject, 0.25f);
        }

        if (coll.gameObject.tag == "Circle")
            TouchManager._hexes--;
        if (coll.gameObject.tag == "Square")
            TouchManager._squares--;
        if (coll.gameObject.tag == "Triangles")
            TouchManager._triangles--;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Circle")
            TouchManager.circleShapePos = coll.gameObject.transform.position;
        if (coll.gameObject.tag == "Square")
            TouchManager.squareShapePos = coll.gameObject.transform.position;
        if (coll.gameObject.tag == "Triangle")
            TouchManager.triangleShapePos = coll.gameObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Circle")
            TouchManager._hexes++;
        if(coll.gameObject.tag == "Square")
            TouchManager._squares++;
        if(coll.gameObject.tag == "Triangle")
            TouchManager._triangles++;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Destroy(coll.gameObject, 0.25f);
    }
}
