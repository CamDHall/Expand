using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTutorial : MonoBehaviour {

	void Start () {
        Destroy(this.GetComponent<Rigidbody2D>());
        this.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        if (this.gameObject.tag == "Freeze")
            this.transform.position = new Vector3(2.5f, 4.25f - (PowerUpManager.freezePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Damage")
            this.transform.position = new Vector3(1.5f, 4.25f - (PowerUpManager.damagePowerups * 0.9f), 0);
        else if (this.gameObject.tag == "Boost")
            this.transform.position = new Vector3(0.5f, 4.25f - (PowerUpManager.boostPowerups * 0.9f), 0);
    }
}
