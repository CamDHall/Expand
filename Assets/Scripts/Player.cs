using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    float addMass;
    static public float currentScale;
    public static Vector3 Pos;

    // Scaling
    float shrink;
    Vector3 newScale;
    public float speed = 0.6f;
    bool notTouching = true;

    public static bool madeGoal = false;

    // Camera Shake
    public GameObject CameraShake;

	void Start () {
        newScale = new Vector3(0.75f, 0.75f, 0);
	}

    void Update()
    {
        if(transform.localScale.x < 0.75f)
        {
            SceneManager.LoadScene("End");
        }
        currentScale = transform.localScale.x;

        foreach (Touch touch in Input.touches)
        {
            Pos = Camera.main.ScreenToWorldPoint(touch.position);

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
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -8.5f && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 8.5f)
            {
                Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(Pos.x, transform.position.y, 0);
            }

            addMass += (.001f * Time.deltaTime);
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
            Scoring.Score += 50f;
        }

        if(coll.gameObject.tag == "Goal")
        {
            Scoring.Score += (coll.transform.localScale.x * 50f);
            Destroy(coll.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        CameraShake.gameObject.SendMessage("DoShake");
        transform.localScale -= new Vector3(transform.localScale.x * 0.85f, transform.localScale.y * 0.85f, 0);
        Destroy(coll.gameObject);
    }
}
