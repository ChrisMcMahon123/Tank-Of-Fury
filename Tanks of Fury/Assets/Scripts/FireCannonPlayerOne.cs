using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannonPlayerOne : MonoBehaviour {
	public ParticleSystem cannonFireAnimation;
	public Slider cannonPowerSlider;

	private float coolDownTimer;

	void Start() {
		cannonFireAnimation.Stop ();
		coolDownTimer = 0;
	}

	void Update () {
		if (Mathf.Round(coolDownTimer) <= 0) {
			//prevent the player from spamming the fire button resulting in some funny bullet physics 
			if (Input.GetKey ("f")) {
				if (GlobalVariables.CurrentPlayerTurn == 1) {
					Debug.Log ("Player 1 FIRE");
					//gun has been fired, set the cooldown timer and shoot the bullet
					coolDownTimer = GlobalVariables.coolDownPeriod;
					cannonFireAnimation.Play ();
					fireBullet (cannonFireAnimation.transform.position, transform.up * cannonPowerSlider.value * GlobalVariables.cannonMultiplier * Time.deltaTime);
				}
			}
			else {
				cannonFireAnimation.Stop ();
			}
		}
		else {
			//dont show the firing animation if the gun is still cooling down
			//reduce the cooldown timer
			coolDownTimer -= Time.deltaTime;
			cannonFireAnimation.Stop ();
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