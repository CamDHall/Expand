using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    // Sizing
    Vector3 screenDimensions;
    float screenWidth;

    void Awake()
    {
        screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        screenWidth = screenDimensions.x;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            // Freeze
            if (this.gameObject.tag == "Freeze")
            {
                PositionPowerup();
                PowerUpManager.freezePowerups++;
                this.gameObject.tag = "CanFreeze";
            }

            // Destroy
            if(this.gameObject.tag == "Damage")
            {
                PositionPowerup();
                PowerUpManager.damagePowerups++;
                this.gameObject.tag = "CanDamage";
            }

            // Boost
            if(this.gameObject.tag == "Boost")
            {
                PositionPowerup();
                PowerUpManager.boostPowerups++;
                this.gameObject.tag = "CanBoost";
            }
        }
    }

    void PositionPowerup()
    {
        Destroy(this.GetComponent<Rigidbody2D>());
        this.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        if (this.gameObject.tag == "Freeze")
            this.transform.position = new Vector3(screenWidth - 1f, (screenDimensions.y - 1f) - (PowerUpManager.freezePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Damage")
            this.transform.position = new Vector3(screenWidth - 2f, (screenDimensions.y - 1f) - (PowerUpManager.damagePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Boost")
            this.transform.position = new Vector3(screenWidth - 3f, (screenDimensions.y - 1f) - (PowerUpManager.boostPowerups * 0.9f), 0);
    }
}
