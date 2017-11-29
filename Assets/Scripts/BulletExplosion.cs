using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		//destroy the bullet at any point where it collides with anything
		//also generating an AOE effect that will grow

		if (GlobalVariables.playerOneCurrentAmmoType.CompareTo ("NormalAmmo") == 0) {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			GetComponent<Collider> ().isTrigger = true;
			gameObject.tag = "AOEDamage";
			Destroy (GetComponent<Rigidbody> ());
			GetComponent<Renderer> ().material = Resources.Load ("Explosion", typeof(Material)) as Material;
			gameObject.AddComponent (System.Type.GetType ("GrowAOE"));
		} 

		/*else if (GlobalVariables.playerOneCurrentAmmoType.CompareTo ("LaserAmmo") == 0) {
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}*/
			


	}

	void OnTriggerEnter(Collider collider) {

		if (collider.tag == "Terrain") {
			Destroy (collider.gameObject);
		}
		Destroy (gameObject);
	}
		
}