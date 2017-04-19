using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    PowerUpManager manager;

	void Start () {
        manager = GameObject.FindGameObjectWithTag("PowerUpManager").GetComponent<PowerUpManager>();
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            // Freeze
            if(this.gameObject.tag == "Freeze")
            {
                PositionPowerup();
                manager.freezePowerups++;
                PowerUpManager.freezeTimer = Time.timeSinceLevelLoad + 5f;
                manager.freeze = true;
            }

            // Destroy
            if(this.gameObject.tag == "Damage")
            {
                PositionPowerup();
                manager.damagePowerups++;
                // manager.damage = true;
            }

            // Boost
            if(this.gameObject.tag == "Boost")
            {
                PositionPowerup();
                manager.boostPowerups++;
                // manager.boost = true;
            }

            // Destroy(this.gameObject);
        }
    }

    void PositionPowerup()
    {
        Destroy(this.GetComponent<Rigidbody2D>());
        this.transform.localScale -= (this.transform.localScale / 3.5f);

        if (this.gameObject.tag == "Freeze")
            this.transform.position = new Vector3(2.5f, 4.25f - (manager.freezePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Damage")
            this.transform.position = new Vector3(1.5f, 4.25f - (manager.damagePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Boost")
            this.transform.position = new Vector3(0.5f, 4.25f - (manager.boostPowerups * 0.9f), 0);
    }
}
