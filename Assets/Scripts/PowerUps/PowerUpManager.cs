using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public float freezeTimer;
    public bool freeze;
    List<GameObject> currentShapes;

	void Start () {
		
	}
	
	void Update () {
		if(freezeTimer > Time.timeSinceLevelLoad)
        {
            foreach(GameObject shape in Shapes.obstacleShapes)
            {
                shape.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        if(freezeTimer <= Time.timeSinceLevelLoad && freeze)
        {
            UnFreeze();
            freeze = false;
        }
	}

    void UnFreeze()
    {
        foreach (GameObject shape in Shapes.obstacleShapes)
        {
            shape.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
