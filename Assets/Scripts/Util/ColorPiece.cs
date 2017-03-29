using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (transform.parent != null)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        } else
        {
            float gravity = Player.currentScale / 10;
            GetComponent<Rigidbody2D>().gravityScale = gravity;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
	}
}
