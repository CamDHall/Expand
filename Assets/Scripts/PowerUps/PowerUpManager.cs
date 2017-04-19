using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    static public float freezeTimer;
    public bool freeze, damage, boost;
    public int freezePowerups = 0, damagePowerups = 0, boostPowerups;
    List<GameObject> currentShapes;

	void Start () {
        freezeTimer = 0;
	}
	
	void Update () {
		if(freezeTimer > Time.timeSinceLevelLoad)
        {
            for(int i = 0; i < Shapes.obstacleShapes.Count; i++)
            {
                Debug.Log(Shapes.obstacleShapes[i].name);
                Shapes.obstacleShapes[i].GetComponent<Rigidbody2D>().drag = 5f;
            }
        }

        if(freezeTimer <= Time.timeSinceLevelLoad)
        {
            // UnFreeze();
        }

        if(damage)
        {
            damage = false;
            Explode();
        }

        if(boost)
        {
            boost = false;
            Boost();
        }
	}

    void UnFreeze()
    {
        foreach (GameObject shape in Shapes.obstacleShapes)
        {
            shape.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

    void Explode()
    {
        foreach(GameObject shape in Shapes.obstacleShapes)
        {
            shape.transform.DetachChildren();
            Destroy(shape);
        }
    }

    void Boost()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale += new Vector3(5, 5, 0);
    }
}
