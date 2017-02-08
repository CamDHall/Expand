using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    float addMass;
    static public float currentScale;

    // Scaling
    float shrink;
    Vector3 newScale;
    public float speed = 0.6f;
    bool notTouching = true;

    public static bool madeGoal = false;

	void Start () {
        newScale = new Vector3(0.5f, 0.5f, 0);
	}

    void Update()
    {
        currentScale = transform.localScale.x;

        foreach (Touch touch in Input.touches)
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint(touch.position);

            transform.position = new Vector3(Pos.x, transform.position.y, 0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                addMass = Input.GetTouch(0).deltaTime / 5f;
                notTouching = false;
                transform.localScale = new Vector3(transform.localScale.x + addMass, transform.localScale.y + addMass, 0);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                notTouching = true;
            }
        }

        if(notTouching)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, speed * Time.deltaTime);
        }


        //
        // Mouse Input
        //
        if(Input.GetMouseButton(0))
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Pos.x, transform.position.y, 0);

            addMass += (.005f * Time.deltaTime);
            notTouching = false;
            transform.localScale = new Vector3(transform.localScale.x + addMass, transform.localScale.y + addMass, 0);
        }

        if(Input.GetMouseButtonUp(0))
        {
            notTouching = true;
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("End");
        }

        if(coll.gameObject.tag == "Goal")
        {
            Scoring.Score += 100f;
        }
    }
}
