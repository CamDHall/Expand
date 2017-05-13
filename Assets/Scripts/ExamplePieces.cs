using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePieces : MonoBehaviour {

	public GameObject squareUI, hexUI;
    Color defaultColor;
	
    void Awake()
    {
        defaultColor = new Color(0.4352941176470588f, 0.4352941176470588f, 0.4352941176470588f, 1);
    }

	void Update () {
        float gravity = Player.currentScale / 10;
        GetComponent<Rigidbody2D>().gravityScale = gravity;

        if ((gameObject.tag == "hexColorPiece" || gameObject.tag == "hexLast") && transform.parent == null)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(gameObject.tag == "hexLast")
            {
                squareUI.GetComponent<SpriteRenderer>().material.color = defaultColor;
                hexUI.GetComponent<SpriteRenderer>().material.color = defaultColor;
            } else if (gameObject.tag == "squareColorPiece")
                squareUI.GetComponent<SpriteRenderer>().material.color = GetComponent<SpriteRenderer>().color;
            else
                hexUI.GetComponent<SpriteRenderer>().material.color = GetComponent<SpriteRenderer>().color;

            Destroy(this.gameObject);
        }
    }
}
