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
			//check to see if is fired and which ammo is player currently equip with
			if (Input.GetKey ("f")) {
				if (GlobalVariables.currentPlayerHasFiredCannon == false &&
				    GlobalVariables.playerOneCurrentAmmoType.CompareTo ("NormalAmmo") == 0) { 
					//gun has been fired
					//Debug.Log ("Player 1 FIRE");
					cannonFireAnimation.Play ();
					GlobalVariables.fireCannon (cannonFireAnimation.transform.position, transform.up * cannonPowerSlider.value * GlobalVariables.cannonMultiplier * Time.deltaTime);
				} 
				else if (GlobalVariables.currentPlayerHasFiredCannon == false &&
				        GlobalVariables.playerOneCurrentAmmoType.CompareTo ("LaserAmmo") == 0) {
					GlobalVariables.fireLazer (cannonFireAnimation.transform.position, transform.up * cannonPowerSlider.value * GlobalVariables.cannonMultiplier * Time.deltaTime);
					GlobalVariables.laserStocks -= 1;

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