using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		//destroy the bullet at any point where it collides with anything
		//also generating an AOE effect that will grow
		Debug.Log ("Collision Destroy");
		Destroy (gameObject);
	}
}
