using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannon : MonoBehaviour {
	public ParticleSystem cannonFire;//animation for cannon fire
	public Slider powerSlider;

	private float coolDownTimer;
	private float coolDownPeriod;
	private bool overheat;

	void Start() {
		coolDownPeriod = 1.0f;
		coolDownTimer = 0;
		cannonFire.Stop ();
	}

	// Update is called once per frame
	void Update () {
		if (Mathf.Round(coolDownTimer) <= 0) {
			//prevent the player from spamming the fire button resulting in some funny bullet physics 
			if (Input.GetKey ("space")) {
				//gun has been fired, set the cooldown timer and shoot the bullet
				coolDownTimer = coolDownPeriod;
				cannonFire.Play ();
				fireBullet (cannonFire.transform.position, transform.up * powerSlider.value * 1000 * Time.deltaTime);
			} else {
				cannonFire.Stop ();
			}
		}
		else {
			//dont show the firing animation if the gun is still cooling down
			//reduce the cooldown timer
			coolDownTimer -= Time.deltaTime;
			cannonFire.Stop ();
		}
	}

	private void fireBullet(Vector3 spawnLocation, Vector3 forceApplied) {
		GameObject newBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		newBullet.transform.localScale = new Vector3(.5f,.5f,.5f);
		newBullet.transform.position = spawnLocation;

		newBullet.GetComponent<Renderer> ().material = Resources.Load ("Bullet", typeof(Material)) as Material;

		newBullet.AddComponent(System.Type.GetType("BulletExplosion"));

		newBullet.AddComponent<Rigidbody>();
		newBullet.GetComponent<Rigidbody>().AddForce(forceApplied);
	}
}
