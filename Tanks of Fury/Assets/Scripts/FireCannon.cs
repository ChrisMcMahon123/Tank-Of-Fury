using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour {
	public ParticleSystem cannonFire;//animation for cannon fire

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("space")) {
			cannonFire.Play ();
		} else {
			cannonFire.Stop ();
		}
	}
}
