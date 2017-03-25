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

    // Rings
    List<Color32> totalColors = new List<Color32>()
    {
        new Color32(0x4C, 0xB5, 0xAE, 0xFF),
        new Color32(0x81, 0xD6, 0xE3, 0xFF),
        new Color32(0xA9, 0xDB, 0xB8, 0xFF),
        new Color32(0xF4, 0x00, 0x00, 0xFF),
        new Color32(0xB4, 0xB8, 0xAB, 0xFF)
    };

    public static bool madeGoal = false;

    // Camera Shake
    public GameObject CameraShake;

	void Start () {
        newScale = new Vector3(0.75f, 0.75f, 0);
	}

    void Update()
    {

        // TEST MOUSE
            Vector3 Pos = Input.mousePosition;
            Pos = Camera.main.ScreenToWorldPoint(Pos);
            transform.position = new Vector3(Pos.x, transform.position.y, transform.position.z);
        // TEST MOUSE

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

        if(coll.gameObject.tag == "circlePiece")
        {
            Destroy(coll.gameObject);
            LevelManager.circleFillLevel += 0.5f;
        }

        if(coll.gameObject.tag == "squarePiece")
        {
            Destroy(coll.gameObject);
            LevelManager.squareFillLevel += 0.25f;
        }

        if(coll.gameObject.tag == "trianglePiece")
        {
            Destroy(coll.gameObject);
            LevelManager.triangleFillLevel += 0.2f;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        CameraShake.gameObject.SendMessage("DoShake");
        transform.localScale -= new Vector3(transform.localScale.x * 0.85f, transform.localScale.y * 0.85f, 0);
        Destroy(coll.gameObject);
    }
}
