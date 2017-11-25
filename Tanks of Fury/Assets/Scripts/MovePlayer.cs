using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//camera will now follow player, camera controls are currently disabled
public class MovePlayer : MonoBehaviour {
	private bool isGrounded;

	void Update () {
		if (GlobalVariables.currentPlayerHasFiredCannon == false) {
			if (GlobalVariables.currentPlayerMaxTravelDistance == false) {
				//moving the player based on user input
				if (Input.GetKey ("w")) {
					//move object in the forward direction thats its facing
					GlobalVariables.currentPlayerTank.transform.position += GlobalVariables.currentPlayerTank.transform.forward * GlobalVariables.moveSpeed * Time.deltaTime;
					updateFuelConsumption ();
				}

				if (Input.GetKey ("s")) {
					//move object in the backward direction thats its facing
					GlobalVariables.currentPlayerTank.transform.position -= GlobalVariables.currentPlayerTank.transform.forward * GlobalVariables.moveSpeed * Time.deltaTime;
					updateFuelConsumption ();
				}

				if (Input.GetKeyDown ("space")) {
					if (isGrounded == true) {
						//jump!
						GlobalVariables.currentPlayerTank.transform.Translate (Vector3.up * GlobalVariables.jumpSpeed * Time.deltaTime, Space.World);
					}
				} 
			} 
			else {
				GlobalVariables.currentPlayerFuelLevel = 0;
				GlobalVariables.currentPlayerFuelText.text = GlobalVariables.currentPlayerFuelLevel.ToString();
			}
	
			if (Input.GetKey ("a")) {
				//rotate camera left along y axis
				GlobalVariables.currentPlayerTank.transform.RotateAround (GlobalVariables.currentPlayerTank.transform.position, Vector3.down, 2 * GlobalVariables.moveSpeed * Time.deltaTime);//rotate around self
			}

			if (Input.GetKey ("d")) {
				//move camera right along y axis
				GlobalVariables.currentPlayerTank.transform.RotateAround (GlobalVariables.currentPlayerTank.transform.position, Vector3.up, 2 * GlobalVariables.moveSpeed * Time.deltaTime);//rotate around self
			}
		}
	}
		
	void OnCollisionEnter(Collision collision) {
		isGrounded = true;//the player has returned to the 'ground'
	}

	void OnCollisionExit(Collision collision) {	
		isGrounded = false;//the player has gone airborne, don't let them jump
	}

	void updateFuelConsumption() {
		GlobalVariables.currentPlayerFuelLevel -= (int) (Vector3.Distance(GlobalVariables.currentPlayerStartingLocation,GlobalVariables.currentPlayerTank.transform.position)) / GlobalVariables.fuelMultiplier;
		GlobalVariables.currentPlayerFuelText.text = GlobalVariables.currentPlayerFuelLevel.ToString();

		if (GlobalVariables.currentPlayerFuelLevel <= 0) {
			GlobalVariables.currentPlayerMaxTravelDistance = true;
		}
	}
}