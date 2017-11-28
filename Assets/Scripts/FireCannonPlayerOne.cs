using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannonPlayerOne : MonoBehaviour {
	public ParticleSystem cannonFireAnimation;
	public Slider cannonPowerSlider;

	void Start() {
		cannonFireAnimation.Stop ();
	}

	void Update () {
		if (GlobalVariables.CurrentPlayerTurn == 1) {
			if (GlobalVariables.currentPlayerHasFiredCannon == false) {
				if (Input.GetKey ("f")) {
					//gun has been fired
					//Debug.Log ("Player 1 FIRE");
					cannonFireAnimation.Play ();
					GlobalVariables.fireCannon (cannonFireAnimation.transform.position, transform.up * cannonPowerSlider.value * GlobalVariables.cannonMultiplier * Time.deltaTime);
				}
			} 
			else {
				cannonFireAnimation.Stop ();
			}
		}
		else {
			cannonFireAnimation.Stop ();
		}
	}
}