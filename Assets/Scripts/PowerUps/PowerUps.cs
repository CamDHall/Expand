using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            // Freeze
            if(this.gameObject.tag == "Freeze")
            {
                PositionPowerup();
                PowerUpManager.freezePowerups++;
            }

            // Destroy
            if(this.gameObject.tag == "Damage")
            {
                PositionPowerup();
                PowerUpManager.damagePowerups++;
            }

            // Boost
            if(this.gameObject.tag == "Boost")
            {
                PositionPowerup();
                PowerUpManager.boostPowerups++;
            }
        }
    }

    void PositionPowerup()
    {
        Destroy(this.GetComponent<Rigidbody2D>());
        this.transform.localScale -= (this.transform.localScale / 3.5f);

        if (this.gameObject.tag == "Freeze")
            this.transform.position = new Vector3(2.5f, 4.25f - (PowerUpManager.freezePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Damage")
            this.transform.position = new Vector3(1.5f, 4.25f - (PowerUpManager.damagePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Boost")
            this.transform.position = new Vector3(0.5f, 4.25f - (PowerUpManager.boostPowerups * 0.9f), 0);
    }
}
