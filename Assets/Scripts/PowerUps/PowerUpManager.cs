using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    static public float freezeTimer;
    float freezeDrag = 5;
    static public bool freeze, damage, boost;
    static public int freezePowerups = 0, damagePowerups = 0, boostPowerups;
    List<GameObject> currentShapes;
    List<string> possibleChoices;

    // Spawning info
    public GameObject _freezePrefab, _damagePrefab, _boostPrefab;
    Vector3 newPowerUpPos;
    float xPosLow = -2.5f, xPosHigh = 2.5f, yPosLow = 5f, yPosHigh = 6.5f;

    string lastChoice;
    float gravity;

    static public int numFull = 0;

    static public List<GameObject> currentPowerups;

	void Start () {
        freezeTimer = 0;
        currentPowerups = new List<GameObject>();

        possibleChoices = new List<string>()
        {
            "Freeze",
            "Damage",
            "Boost"
        };

        freeze = false;
        damage = false;
        boost = false;

        freezePowerups = 0;
        damagePowerups = 0;
        boostPowerups = 0;
        numFull = 0;
	}
	
	void Update () {
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
            Destroy(shape);
        }

        Shapes.obstacleShapes.Clear();

        Debug.Log(Shapes.obstacleShapes.Count);
    }

    void Boost()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale += new Vector3(5, 5, 0);
        foreach(GameObject powerup in currentPowerups)
        {
            if(powerup.tag == "Boost")
            {
                powerup.transform.position = new Vector3(powerup.transform.position.x, (powerup.transform.position.y - 1), 0);
            }
        }
    }

    public void GeneratePowerUp()
    {
        newPowerUpPos = new Vector3(Random.Range(xPosLow, xPosHigh), Random.Range(yPosLow, yPosHigh), 0);
        gravity = Player.currentScale / 10;

        string choice = GenerateChoice();
        if (choice == "Freeze")
            SpawnFreeze();
        else if (choice == "Damage")
            SpawnDamage();
        else
            SpawnBoost();
    }

    public string GenerateChoice()
    {
        bool reRolled = false;
        string choice = "";

        Debug.Log("FREEZE: " + freezePowerups + " DAMAGE: " + damagePowerups + " BOOST" + boostPowerups);

        if (freezePowerups >= 3)
            possibleChoices.Remove("Freeze");
        if (damagePowerups >= 3)
            possibleChoices.Remove("Damage");
        if (boostPowerups >= 3)
            possibleChoices.Remove("Boost");


        int evenChoice = Random.Range(0, 3);

        int unevenChoice = Random.Range(0, possibleChoices.Count);

        if (lastChoice == null)
        {
            choice = possibleChoices[evenChoice];
            Debug.Log(evenChoice);
        }
        else
            if (lastChoice == possibleChoices[unevenChoice] && !reRolled)
        {
            unevenChoice = Random.Range(0, possibleChoices.Count - 1);
            reRolled = true;
        }
            choice = possibleChoices[unevenChoice];

        return choice;
    }

    void SpawnFreeze()
    {
        GameObject newFreeze = Instantiate(_freezePrefab);
        newFreeze.GetComponent<Rigidbody2D>().gravityScale = Player.currentScale / 10f;

        currentPowerups.Add(newFreeze);
        lastChoice = "Freeze";
    }

    void SpawnDamage()
    {
        GameObject newDamage = Instantiate(_damagePrefab);
        newDamage.GetComponent<Rigidbody2D>().gravityScale = Player.currentScale / 10f;

        currentPowerups.Add(newDamage);
        lastChoice = "Damage";
    }

    void SpawnBoost()
    {
        GameObject newBoost = Instantiate(_boostPrefab);
        newBoost.GetComponent<Rigidbody2D>().gravityScale = Player.currentScale / 10f;

        currentPowerups.Add(newBoost);
        lastChoice = "Boost";
    }
}
