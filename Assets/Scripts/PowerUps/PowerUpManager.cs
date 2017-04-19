using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    static public float freezeTimer;
    float freezeDrag = 5;
    public bool freeze, damage, boost;
    public int freezePowerups = 0, damagePowerups = 0, boostPowerups;
    List<GameObject> currentShapes;

	void Start () {
        freezeTimer = 0;
	}
	
	void Update () {

        Debug.Log(freezeTimer);

		if(freeze && freezeTimer > Time.timeSinceLevelLoad)
        {
            Debug.Log(freezeDrag);
            if (freezeDrag > 0)
            {
                freezeDrag -= Time.deltaTime;
            } else
            {
                freezeDrag = 5f;
                freeze = false;
            }

            foreach(GameObject shape in Shapes.obstacleShapes)
            {
                shape.GetComponent<Rigidbody2D>().drag = freezeDrag;
            }
        } else
        {
            UnFreeze();
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
            if (shape != null)
            {
                shape.GetComponent<Rigidbody2D>().drag = 0;
                freezeDrag = 5f;
            }
        }
    }

    void Explode()
    {
        foreach(GameObject shape in Shapes.obstacleShapes)
        {
            shape.transform.DetachChildren();
            for (int i = Shapes.obstacleShapes.Count - 1; i >= 0; i--)
            {
                Shapes.obstacleShapes.Remove(Shapes.obstacleShapes[i]);
            }
            Destroy(shape);
        }
    }

    void Boost()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale += new Vector3(5, 5, 0);
    }

    void GeneratePowerUp()
    {

    }
}
