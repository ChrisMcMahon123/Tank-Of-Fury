using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
	//for destructable objects using this script they need a RigidBody
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "AOEDamage") {
			Destroy (gameObject);
		}
	}
}