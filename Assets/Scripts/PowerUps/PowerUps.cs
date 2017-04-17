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
                manager.freeze = true;
                manager.freezeTimer = Time.timeSinceLevelLoad + 10f;
            }

            // Destroy
            if(this.gameObject.tag == "Damage")
            {
                manager.damage = true;
            }

            // Boost
            if(this.gameObject.tag == "Boost")
            {
                manager.boost = true;
            }

            Destroy(this.gameObject);
        }
    }
}
